using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.VisualBasic;

namespace FCM_BSO
{
    public partial class Form1 : Form
    {
        public static int data_set_rows = 150;
        public static int data_set_attr = 5;
        public static int num_clusters = 3;
        public static int max_iteration = 20;
        public static int taamjhaam_k = 20;           //Refer to equation 3 in Modified BSO
        public static int fuzzy_index = 3;
        public static string dataSetPath = "DataSets\\iris.csv";
        public static string initial_cc = "";
        int iteration = 0;
        
        double[,] Y = new double[data_set_rows, data_set_attr];
        double[,] data_set = new double[data_set_rows, data_set_attr];
        double[,] cluster_centers = new double[num_clusters, data_set_attr];

        double[] mean = new double[data_set_attr-1];
        double[] variance = new double[data_set_attr-1];
        double[,] covariance_matrix = new double[data_set_attr-1, data_set_attr-1];     //Covariance matrix of feature vectors
        double[,] m_inverse = new double[data_set_attr-1, data_set_attr-1];             //Inverse of covariance matrix
        double determinant_covariance = 0;

        int[,] clusters = new int[num_clusters, data_set_rows];

        int[] clusters_cnt = Enumerable.Repeat(0, num_clusters).ToArray();
        int[] best_ideas = new int[num_clusters];
        double[,] meu = new double[data_set_rows, num_clusters];
        //double[,] euclidean = new double[data_set_rows, num_clusters];
        double[,] mahalanobis = new double[data_set_rows, num_clusters];
        double p_replace = 0.2, p_one = 0.8, p_one_center = 0.4, p_two_center = 0.5;

        long totalellapsedmilliseconds = 0;

        public Form1()
        {
            InitializeComponent();

        }

        double determinant(double[,] matrix,double size)
        {
            double s=1,det=0;
            double[,] m_minor = new double[data_set_attr-1,data_set_attr-1];
            int i,j,m,n,c;
            if (size==1)
            {
                return (matrix[0,0]);
            }
            else
            {
                det=0;
                for (c=0;c<size;c++)
                {
                    m=0;
                    n=0;
                    for (i=0;i<size;i++)
                    {
                        for (j=0;j<size;j++)
                        {
                            m_minor[i,j]=0;
                            if (i != 0 && j != c)
                            {
                               m_minor[m,n]=matrix[i,j];
                               if (n<(size-2))
                                  n++;
                               else
                               {
                                   n=0;
                                   m++;
                               }
                            }
                        }
                    }
                    det=det + s * (matrix[0,c] * determinant(m_minor,size-1));
                    s=-1 * s;
                }
            }
 
            return (det);
        }
 
         /*calculate cofactor of matrix*/
        void cofactor(double[,] matrix,double size)
        {
             double[,] m_cofactor = new double[data_set_attr-1,data_set_attr-1];
             double[,] matrix_cofactor = new double[data_set_attr-1,data_set_attr-1];
             int p,q,m,n,i,j;
             for (q=0;q<size;q++)
             {
                 for (p=0;p<size;p++)
                 {
                     m=0;
                     n=0;
                     for (i=0;i<size;i++)
                     {
                         for (j=0;j<size;j++)
                         {
                             if (i != q && j != p)
                             {
                                m_cofactor[m,n]=matrix[i,j];
                                if (n<(size-2))
                                   n++;
                                else
                                {
                                    n=0;
                                    m++;
                                }
                             }
                         }
                     }
                     matrix_cofactor[q,p]=Math.Pow(-1,q + p) * determinant(m_cofactor,size-1);
                 }
             }
             transpose(matrix,matrix_cofactor,size);
        }
 
        /*Finding transpose of cofactor of matrix*/ 
        void transpose(double[,] matrix,double[,] matrix_cofactor,double size)
        {
             int i,j;
             double[,] m_transpose = new double[data_set_attr-1, data_set_attr-1];

             double d;
 
             for (i=0;i<size;i++)
             {
                 for (j=0;j<size;j++)
                 {
                     m_transpose[i,j]= matrix_cofactor[j,i];
                 }
             }
             d= determinant(matrix,size);
             for (i=0;i<size;i++)
             {
                 for (j=0;j<size;j++)
                 {
                     m_inverse[i,j]=m_transpose[i,j] / d;
                 }
             }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var reader = new StreamReader(File.OpenRead(dataSetPath));

            //Type 0 in the csv stands for setosa, type 1 stands for verginica and type 2 stands for versicolor

            int i = 0, j = 0;
            iteration = 0;
            totalellapsedmilliseconds = 0;
            for (i = 0; i < num_clusters; i++)
            {
                clusters_cnt[i] = 0;
            }
            i = 0;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');   //This contains complete row cells
                if (i != 0)
                {
                    for (j = 0; j < data_set_attr; j++)
                    {
                        data_set[i - 1, j] = Convert.ToDouble(values[j]);
                        if(j!=0)
                            mean[j-1] += data_set[i - 1, j];
                    }
                }
                i++;
            }

            //mean and variance calculation of dataset
            for (i = 0; i < data_set_attr-1; i++)
            {
                mean[i] = mean[i] / data_set_rows;

                for (j = 0; j < data_set_rows; j++)
                {
                        variance[i] += Math.Pow((data_set[j, i+1] - mean[i]), 2);
                }
                variance[i] = variance[i] / (data_set_rows - 1);
            }

            //Covariance matrix calculation of dataset
            for (i = 0; i < data_set_attr-1; i++)
            {
                for (j = 0; j < data_set_attr-1; j++)
                {
                    for (int k = 0; k < data_set_rows; k++)
                    {
                        covariance_matrix[i,j] = covariance_matrix[i,j] + ((data_set[k,i+1] - mean[i]) * (data_set[k,j+1] - mean[j]));
                    }
                    covariance_matrix[i, j] = covariance_matrix[i, j] / data_set_rows;
                }
            }

            determinant_covariance = 0;
            determinant_covariance = determinant(covariance_matrix, data_set_attr-1);
            if (determinant_covariance != 0)
                cofactor(covariance_matrix, data_set_attr-1);

            //Lets select first k data points as k cluster centers respectively

            var cc = initial_cc.Split(',');
            for(i=0; i<num_clusters; i++)
                for(j=0; j<data_set_attr; j++)
                    cluster_centers[i, j] = data_set[Convert.ToInt32(cc[i])-2, j];

            lblItrCount.Visible = true;

            chart1.Series.Clear();
            chart2.Series.Clear();
            chart3.Series.Clear();
            chart4.Series.Clear();
            chart5.Series.Clear();
            chart6.Series.Clear();

            for (i = 0; i < num_clusters; i++)
            {
                chart1.Series.Add("cluster_"+i);
                chart1.Series["cluster_" + i].ChartType = SeriesChartType.Point;

                chart2.Series.Add("cluster_" + i);
                chart2.Series["cluster_" + i].ChartType = SeriesChartType.Point;

                chart3.Series.Add("cluster_" + i);
                chart3.Series["cluster_" + i].ChartType = SeriesChartType.Point;

                chart4.Series.Add("cluster_" + i);
                chart4.Series["cluster_" + i].ChartType = SeriesChartType.Point;

                chart5.Series.Add("cluster_" + i);
                chart5.Series["cluster_" + i].ChartType = SeriesChartType.Point;

                chart6.Series.Add("cluster_" + i);
                chart6.Series["cluster_" + i].ChartType = SeriesChartType.Point;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i, j, k;
            iteration++;

            lbldbindex_c4.Visible = true;
            lbldbindex_c5.Visible = true;
            lbldbindex_c6.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;

            lblItrCount.Text = "Iteration Count = " + Convert.ToString(iteration);

            // Create new stopwatch
            Stopwatch stopwatch = new Stopwatch();
            // Begin timing
            stopwatch.Start();

            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            foreach (var series in chart2.Series)
            {
                series.Points.Clear();
            }
            foreach (var series in chart3.Series)
            {
                series.Points.Clear();
            }
            foreach (var series in chart4.Series)
            {
                series.Points.Clear();
            }
            foreach (var series in chart5.Series)
            {
                series.Points.Clear();
            }
            foreach (var series in chart6.Series)
            {
                series.Points.Clear();
            }
            //chart1.Series["SL"].Color = Color.Green;

            for (i = 0; i < num_clusters; i++)
            {
                clusters_cnt[i] = 0;
            }

            for (i = 0; i < data_set_rows; i++)
            {
                double max_meu = meu[i,0];
                int max_meu_j = 0;

                for (j = 0; j < num_clusters; j++)
                {
                    double temp = 0;

                    for (k = 0; k < num_clusters; k++)
                    {
                        if (determinant_covariance == 0)
                        {
                            mahalanobis[i, j] = 0;
                            for (int p = 1; p <= data_set_attr - 1; p++)
                            {
                                mahalanobis[i, j] += ((data_set[i, p] - cluster_centers[j, p]) * (data_set[i, p] - cluster_centers[j, p]));
                            }

                            mahalanobis[i, k] = 0;
                            for (int p = 1; p <= data_set_attr - 1; p++)
                            {
                                mahalanobis[i, k] += ((data_set[i, p] - cluster_centers[k, p]) * (data_set[i, p] - cluster_centers[k, p]));
                            }
                        }
                        else
                        {
                            mahalanobis[i, j] = 0;
                            double[,] c = new double[1, data_set_attr-1];

                            for (int ii = 0; ii < 1; ii++)
                            {
                                for (int jj = 0; jj < data_set_attr-1; jj++)
                                {
                                    c[ii, jj] = 0;

                                    for (int kk = 0; kk < data_set_attr-1; kk++)
                                    {
                                        c[ii, jj] = c[ii, jj] + ((data_set[i, kk] - cluster_centers[j, kk]) * m_inverse[kk, jj]);
                                    }
                                }
                            }
                            for (int ii = 0; ii < 1; ii++)
                            {
                                for (int jj = 0; jj < 1; jj++)
                                {
                                    for (int kk = 0; kk < data_set_attr-1; kk++)
                                    {
                                        mahalanobis[i, j] = mahalanobis[i, j] + ((c[ii, kk]) * (data_set[i, kk] - cluster_centers[j, kk]));
                                    }
                                }
                            }

                            mahalanobis[i, k] = 0;
                            for (int ii = 0; ii < 1; ii++)
                            {
                                for (int jj = 0; jj < data_set_attr-1; jj++)
                                {
                                    c[ii, jj] = 0;

                                    for (int kk = 0; kk < data_set_attr-1; kk++)
                                    {
                                        c[ii, jj] = c[ii, jj] + ((data_set[i, kk] - cluster_centers[k, kk]) * m_inverse[kk, jj]);
                                    }
                                }
                            }
                            for (int ii = 0; ii < 1; ii++)
                            {
                                for (int jj = 0; jj < 1; jj++)
                                {
                                    for (int kk = 0; kk < data_set_attr-1; kk++)
                                    {
                                        mahalanobis[i, k] = mahalanobis[i, k] + ((c[ii, kk]) * (data_set[i, kk] - cluster_centers[k, kk]));
                                    }
                                }
                            }
                        }
                        mahalanobis[i, j] = Math.Sqrt(mahalanobis[i, j]);
                        mahalanobis[i, k] = Math.Sqrt(mahalanobis[i, k]);
                        if (mahalanobis[i, k] != 0)
                            temp = temp + (Math.Pow((mahalanobis[i, j] / mahalanobis[i, k]), (2 / (fuzzy_index - 1))));
                        else if (mahalanobis[i, j] !=0 )
                            temp = 9999999999;
                    }

                    if (temp == 0)
                        meu[i, j] = 1;
                    else
                        meu[i, j] = 1 / temp;

                    if (temp >= 9999999999)
                        meu[i, j] = 0;

                    if (max_meu < meu[i, j])
                    {
                        max_meu = meu[i, j];
                        max_meu_j = j;
                    }
                }

                clusters[max_meu_j, (clusters_cnt[max_meu_j])++] = i;

                chart1.Series["cluster_" + max_meu_j].Points.AddXY(data_set[i, 1], data_set[i, 2]);     //PW vs PL
                chart2.Series["cluster_" + max_meu_j].Points.AddXY(data_set[i, 1], data_set[i, 3]);     //PW vs SW
                chart3.Series["cluster_" + max_meu_j].Points.AddXY(data_set[i, 2], data_set[i, 3]);     //PL vs SW
                

                chart4.Series["cluster_" + max_meu_j].Points.AddXY(i + 1, meu[i, 0]);
                chart5.Series["cluster_" + max_meu_j].Points.AddXY(i + 1, meu[i, 1]);
                if(radbtnDUMMY.Checked == false && radbtnDiabetes.Checked == false && radbtnPROTEIN.Checked == false)
                    chart6.Series["cluster_" + max_meu_j].Points.AddXY(i + 1, meu[i, 2]);
            }

            for (j = 0; j < num_clusters; j++)
            {
                for (int p = 1; p <= data_set_attr - 1; p++)
                {
                    double temp1 = 0, temp2 = 0;
                    for (i = 0; i < data_set_rows; i++)
                    {
                        temp1 = temp1 + (Math.Pow(meu[i, j], fuzzy_index) * data_set[i, p]);
                        temp2 = temp2 + (Math.Pow(meu[i, j], fuzzy_index));
                    }
                    cluster_centers[j, p] = temp1 / temp2;
                }
            }

            
            //RECORD BEST IDEAS IN EACH CLUSTER
            
            double euclid;
            for (i = 0; i < num_clusters; i++)
            {
                double min_euclid = 10000000; //SUFFICIENTLY LARGE
                for (j = 0; j < clusters_cnt[i]; j++)
                {
                    euclid = 0;
                    for (int p = 1; p <= data_set_attr - 1; p++)
                    {
                        euclid += Math.Pow((cluster_centers[i, p] - data_set[clusters[i,j], p]), 2);
                    }
                    euclid = Math.Sqrt(euclid);
                    if (min_euclid > euclid)
                    {
                        min_euclid = euclid;
                        best_ideas[i] = clusters[i, j];     //Where is it used?
                    }
                }
                //Newly Added
                //Replace cluster centers with best ideas
                for (int p = 1; p <= data_set_attr - 1; p++)
                {
                    cluster_centers[i, p] = data_set[best_ideas[i], p];
                }
                //Newly Added End

                int points = chart1.Series["cluster_" + i].Points.Count;
                chart1.Series["cluster_" + i].Points.AddXY(data_set[best_ideas[i],1],data_set[best_ideas[i],2]);
                chart1.Series["cluster_" + i].Points[points].BorderColor = Color.Black;

                points = chart2.Series["cluster_" + i].Points.Count;
                chart2.Series["cluster_" + i].Points.AddXY(data_set[best_ideas[i], 1], data_set[best_ideas[i], 3]);
                chart2.Series["cluster_" + i].Points[points].BorderColor = Color.Black;

                points = chart3.Series["cluster_" + i].Points.Count;
                chart3.Series["cluster_" + i].Points.AddXY(data_set[best_ideas[i], 2], data_set[best_ideas[i], 3]);
                chart3.Series["cluster_" + i].Points[points].BorderColor = Color.Black;
            }

           
          //  double dunn_1, dunn_2, dunn_3;
            double[] dunn_numerator = new double[num_clusters];
            double[] dunn_denominator = new double[num_clusters];

            double minimum_intercluster_difference = 9999999999;

            for (i = 0; i < num_clusters; i++)
            {
                int points_ = chart1.Series["cluster_" + i].Points.Count;
                double centroid_X = chart1.Series["cluster_" + i].Points[points_ - 1].XValue;
                double centroid_Y = chart1.Series["cluster_" + i].Points[points_ - 1].YValues[0];

                for (j = 0; j < num_clusters; j++)
                {
                    if (i != j)
                    {
                        int points__ = chart1.Series["cluster_" + j].Points.Count;
                        double centroid_X_ = chart1.Series["cluster_" + j].Points[points__ - 1].XValue;
                        double centroid_Y_ = chart1.Series["cluster_" + j].Points[points__ - 1].YValues[0];

                        double dunn_temp = Math.Sqrt(Math.Pow((centroid_X - centroid_X_), 2) + Math.Pow((centroid_Y - centroid_Y_), 2));
                        if (minimum_intercluster_difference > dunn_temp)
                            minimum_intercluster_difference = dunn_temp;
                    }
                }

            }

            double maximum_intracluster_difference = 0;

            for (i = 0; i < num_clusters; i++)
            {
                double dunn_temp = 0;

                int points_ = chart1.Series["cluster_" + i].Points.Count;
                double centroid_X = chart1.Series["cluster_" + i].Points[points_ - 1].XValue;
                double centroid_Y = chart1.Series["cluster_" + i].Points[points_ - 1].YValues[0];
                for (j = 0; j < points_; j++)
                {
                    dunn_temp += Math.Sqrt(Math.Pow((centroid_X - chart1.Series["cluster_" + i].Points[j].XValue), 2) + Math.Pow((centroid_Y - chart1.Series["cluster_" + i].Points[j].YValues[0]), 2)); 
                }

                dunn_temp /= points_;

                if(maximum_intracluster_difference < dunn_temp)
                    maximum_intracluster_difference = dunn_temp;
            }

            lblchart1dunn.Text ="Dunn Index for 1st chart is: " + Convert.ToString((minimum_intercluster_difference/maximum_intracluster_difference));



            Random rnd = new Random();
            double random = rnd.Next(1,10);
            random = random / 10;

            if (random < p_replace) //Step 6 as per MBSO
            {
                int random_cluster = rnd.Next(0, 2);
                int randomly_generated_value=0;

                randomly_generated_value = clusters[random_cluster, rnd.Next(0, clusters_cnt[random_cluster])];

                for(int p = 1; p<=data_set_attr - 1; p++)
                {
                    cluster_centers[random_cluster, p] = data_set[randomly_generated_value, p];
                }
            }   //STEP 8 as per MBSO

            for (i = 0; i < data_set_rows; i++)   //Step 9
            {
                random = rnd.Next(0, 10);
                random /= 10;

                if (random < p_one)     //Step 10
                {
                    int randomly_selected_cluster = 0;
                    double[] cluster_probability = new double[num_clusters];
                    double max_probability;

                    for (int x = 0; x < num_clusters; x++)
                        cluster_probability[x] = (double)clusters_cnt[x] / data_set_rows;

                    max_probability = cluster_probability[0];

                    for (int x = 0; x < num_clusters; x++)
                    {
                        if (cluster_probability[x] > max_probability)
                        {
                            max_probability = cluster_probability[x];
                            randomly_selected_cluster = x;
                        }
                    }

                    random = rnd.Next(0, 10);
                    random /= 10;

                    
                    if (random < p_one_center)  //Step 11
                    {
                        //The idea which is generated newly, whether we have to replace with the cluster center or whether we have to 
                        //find nearest cluster point using euclidean method or whether we have to add the generated point into the data set.
                        for (int p = 1; p <= data_set_attr - 1; p++)
                        {
                            double ekipower = (Math.Pow((cluster_centers[randomly_selected_cluster, p] - mean[p-1]), 2)) / (2 * Math.Pow(variance[p-1], 2));
                            double gaussian = Math.Exp(-ekipower) / (variance[p-1] * Math.Sqrt((44 / 7)));
                            double taamjhaam = ((0.5 * max_iteration - iteration) / taamjhaam_k);
                            double logsigmoid = 1 / (1 + Math.Exp(-taamjhaam));
                            random = rnd.Next(0, 10);
                            random /= 10;
                            double epsi = logsigmoid * random;
                            Y[i, p] = cluster_centers[randomly_selected_cluster, p] + epsi * gaussian;
                        }
                    }
                    else        //Step 14
                    {
                        double[] value = new double[data_set_attr];   //Randomly selected value from a rendomly selected cluster

                        int random1 = rnd.Next(0, clusters_cnt[randomly_selected_cluster]);
                        for (int p = 1; p <= data_set_attr - 1; p++)
                            value[p] = data_set[clusters[randomly_selected_cluster,random1], p];


                        for (int p = 1; p <= data_set_attr - 1; p++)
                        {
                            double ekipower = (Math.Pow((value[p] - mean[p-1]), 2)) / (2 * Math.Pow(variance[p-1], 2));
                            double gaussian = Math.Exp(-ekipower) / (variance[p-1] * Math.Sqrt((44 / 7)));
                            double taamjhaam = ((0.5 * max_iteration - iteration) / taamjhaam_k);
                            double logsigmoid = 1 / (1 + Math.Exp(-taamjhaam));
                            random = rnd.Next(0, 10);
                            random /= 10;
                            double epsi = logsigmoid * random;
                            Y[i, p] = value[p] + epsi * gaussian;
                        }
                    }       //End of if Step 16
                }
                else        //Step 17
                {
                    random = rnd.Next(1, 10);
                    random = random / 10;

                    int X1 = rnd.Next(0, num_clusters - 1);
                    int X2 = rnd.Next(0, num_clusters - 1);

                    if (X1 == X2)
                    {
                        if (X2 == 0)
                            X2 = X2 + 1;
                        else
                            X2 = X2 - 1;
                    }

                    if (random < p_two_center)          //Step 19
                    {
                        
                        double random2 = rnd.Next(0, 10);
                        random2 /= 10;
                        double[] value1 = new double[data_set_attr];   //Randomly selected value from a rendomly selected cluster

                        for (int p = 1; p <= data_set_attr - 1; p++)
                        {
                            value1[p] = (random2 * cluster_centers[X1, p]) + ((1 - random2) * cluster_centers[X2, p]);
                            double ekipower = (Math.Pow((value1[p] - mean[p-1]), 2)) / (2 * Math.Pow(variance[p-1], 2));
                            double gaussian = Math.Exp(-ekipower) / (variance[p-1] * Math.Sqrt((44 / 7)));
                            double taamjhaam = ((0.5 * max_iteration - iteration) / taamjhaam_k);
                            double logsigmoid = 1 / (1 + Math.Exp(-taamjhaam));
                            random = rnd.Next(0, 10);
                            random /= 10;
                            double epsi = logsigmoid * random;
                            Y[i, p] = value1[p] + epsi * gaussian;
                        }

                    }
                    else   //Step 21
                    {
                        double random2 = rnd.Next(0, 10);
                        random2 /= 10;
                        double[] value1 = new double[data_set_attr];   //Randomly selected value from a rendomly selected cluster
                        double[] value2 = new double[data_set_attr];
                        double[] value3 = new double[data_set_attr];

                        int random3 = rnd.Next(0, clusters_cnt[X1]);
                        for (int p = 1; p <= data_set_attr - 1; p++)
                            value1[p] = data_set[clusters[X1,random3], p];
                        
                        random3 = rnd.Next(0, clusters_cnt[X2]);
                        for (int p = 1; p <= data_set_attr - 1; p++)
                            value2[p] = data_set[clusters[X2,random3], p];

                        for (int p = 1; p <= data_set_attr - 1; p++)
                        {
                            value3[p] = (random2 * value1[p]) + ((1 - random2) * value2[p]);
                            double ekipower = (Math.Pow((value3[p] - mean[p-1]), 2)) / (2 * Math.Pow(variance[p-1], 2));
                            double gaussian = Math.Exp(-ekipower) / (variance[p-1] * Math.Sqrt((44 / 7)));
                            double taamjhaam = ((0.5 * max_iteration - iteration) / taamjhaam_k);
                            double logsigmoid = 1 / (1 + Math.Exp(-taamjhaam));
                            random = rnd.Next(0, 10);
                            random /= 10;
                            double epsi = logsigmoid * random;
                            Y[i, p] = value3[p] + epsi * gaussian;
                        }
                    }       //Step 23
                }     //Step 24      
            }

            // Stop timing
            stopwatch.Stop();
            lbltime_taken.Text = "Milliseconds Elapsed for this iteration: " + stopwatch.ElapsedMilliseconds;
            totalellapsedmilliseconds += stopwatch.ElapsedMilliseconds;
            lbltotaltime.Text = "Total Milliseconds Elapsed: " + totalellapsedmilliseconds;

            double[,] Centroids = new double[num_clusters, 2];
            double[] S = new double[num_clusters];
            double[,] M = new double[num_clusters, num_clusters];
            double[,] R = new double[num_clusters, num_clusters];

            for (i = 0; i < num_clusters; i++)
            {
                int points_ = chart4.Series["cluster_" + i].Points.Count;

                for (j = 0; j < points_; j++)
                {
                    Centroids[i, 0] += chart4.Series["cluster_" + i].Points[j].XValue;
                    Centroids[i, 1] += chart4.Series["cluster_" + i].Points[j].YValues[0];
                }

                Centroids[i, 0] = Centroids[i, 0] / points_;
                Centroids[i, 1] = Centroids[i, 1] / points_;

                for (j = 0; j < points_; j++)
                {
                    double xValue = chart4.Series["cluster_" + i].Points[j].XValue;
                    double yValue = chart4.Series["cluster_" + i].Points[j].YValues[0];
                    S[i] = S[i] + Math.Sqrt(Math.Pow((Centroids[i, 0] - xValue), 2) + Math.Pow((Centroids[i, 1] - yValue), 2));
                }
            }

            double max_R = 0;
            for (i = 0; i < num_clusters; i++)
            {
                for (j = i + 1; j < num_clusters; j++)
                {
                    M[i, j] = Math.Sqrt(Math.Pow((Centroids[i, 0] - Centroids[j, 0]), 2) + Math.Pow((Centroids[i, 1] - Centroids[j, 1]), 2));
                    R[i, j] = (S[i] + S[j]) / M[i, j];
                    if (R[i, j] > max_R)
                    {
                        max_R = R[i, j];
                    }
                }
            }
            lbldbindex_c4.Text = Convert.ToString(max_R);

            Centroids = new double[num_clusters, 2];
            S = new double[num_clusters];
            M = new double[num_clusters, num_clusters];
            R = new double[num_clusters, num_clusters];

            for (i = 0; i < num_clusters; i++)
            {
                int points_ = chart5.Series["cluster_" + i].Points.Count;

                for (j = 0; j < points_; j++)
                {
                    Centroids[i, 0] += chart5.Series["cluster_" + i].Points[j].XValue;
                    Centroids[i, 1] += chart5.Series["cluster_" + i].Points[j].YValues[0];
                }

                Centroids[i, 0] = Centroids[i, 0] / points_;
                Centroids[i, 1] = Centroids[i, 1] / points_;

                for (j = 0; j < points_; j++)
                {
                    double xValue = chart5.Series["cluster_" + i].Points[j].XValue;
                    double yValue = chart5.Series["cluster_" + i].Points[j].YValues[0];
                    S[i] = S[i] + Math.Sqrt(Math.Pow((Centroids[i, 0] - xValue), 2) + Math.Pow((Centroids[i, 1] - yValue), 2));
                }
            }

            max_R = 0;
            for (i = 0; i < num_clusters; i++)
            {
                for (j = i + 1; j < num_clusters; j++)
                {
                    M[i, j] = Math.Sqrt(Math.Pow((Centroids[i, 0] - Centroids[j, 0]), 2) + Math.Pow((Centroids[i, 1] - Centroids[j, 1]), 2));
                    R[i, j] = (S[i] + S[j]) / M[i, j];
                    if (R[i, j] > max_R)
                    {
                        max_R = R[i, j];
                    }
                }
            }
            lbldbindex_c5.Text = Convert.ToString(max_R);

            Centroids = new double[num_clusters, 2];
            S = new double[num_clusters];
            M = new double[num_clusters, num_clusters];
            R = new double[num_clusters, num_clusters];

            for (i = 0; i < num_clusters; i++)
            {
                int points_ = chart6.Series["cluster_" + i].Points.Count;

                for (j = 0; j < points_; j++)
                {
                    Centroids[i, 0] += chart6.Series["cluster_" + i].Points[j].XValue;
                    Centroids[i, 1] += chart6.Series["cluster_" + i].Points[j].YValues[0];
                }

                Centroids[i, 0] = Centroids[i, 0] / points_;
                Centroids[i, 1] = Centroids[i, 1] / points_;

                for (j = 0; j < points_; j++)
                {
                    double xValue = chart6.Series["cluster_" + i].Points[j].XValue;
                    double yValue = chart6.Series["cluster_" + i].Points[j].YValues[0];
                    S[i] = S[i] + Math.Sqrt(Math.Pow((Centroids[i, 0] - xValue), 2) + Math.Pow((Centroids[i, 1] - yValue), 2));
                }
            }

            max_R = 0;
            for (i = 0; i < num_clusters; i++)
            {
                for (j = i + 1; j < num_clusters; j++)
                {
                    M[i, j] = Math.Sqrt(Math.Pow((Centroids[i, 0] - Centroids[j, 0]), 2) + Math.Pow((Centroids[i, 1] - Centroids[j, 1]), 2));
                    R[i, j] = (S[i] + S[j]) / M[i, j];
                    if (R[i, j] > max_R)
                    {
                        max_R = R[i, j];
                    }
                }
            }
            lbldbindex_c6.Text = Convert.ToString(max_R);
        }

        private void radbtnIRIS_Click(object sender, EventArgs e)
        {
            data_set_rows = 150;        //Total number of rows excluding header i.e. 1st row
            data_set_attr = 5;          //Including CLASS attribute e.g. Type, PW, PL, SW, SL
            num_clusters = 3;           //Number of classes required
            max_iteration = 20;
            taamjhaam_k = 20;           //Refer to equation 3 in Modified BSO
            fuzzy_index = 3;
            dataSetPath = "DataSets\\iris.csv";
            string invalid_input = "";
            initial_cc = "";
            do
            {
                initial_cc = Interaction.InputBox(invalid_input+"Enter "+Convert.ToString(num_clusters)+" initial cluster centers separated by commas. \nNOTE: Enter the row number from csv sheet", "Cluster Centers", "");
                if (initial_cc == "")
                    invalid_input = "INVALID INPUT!\n";
            } while (initial_cc == "");

            iteration = 0;

            Y = new double[data_set_rows, data_set_attr];
            data_set = new double[data_set_rows, data_set_attr];
            cluster_centers = new double[num_clusters, data_set_attr];

            mean = new double[data_set_attr-1];
            variance = new double[data_set_attr-1];
            covariance_matrix = new double[data_set_attr - 1, data_set_attr - 1];     //Covariance matrix of feature vectors
            m_inverse = new double[data_set_attr - 1, data_set_attr - 1];             //Inverse of covariance matrix
        

            clusters = new int[num_clusters, data_set_rows];

            clusters_cnt = Enumerable.Repeat(0, num_clusters).ToArray();
            best_ideas = new int[num_clusters];
            meu = new double[data_set_rows, num_clusters];
            mahalanobis = new double[data_set_rows, num_clusters];
        }

        private void radbtnPROTEIN_Click(object sender, EventArgs e)
        {
            data_set_rows = 120;
            data_set_attr = 7;
            num_clusters = 2;
            max_iteration = 20;
            taamjhaam_k = 20;
            fuzzy_index = 3;
            dataSetPath = "DataSets\\protein.csv";
            string invalid_input = "";
            initial_cc = "";
            do
            {
                initial_cc = Interaction.InputBox(invalid_input + "Enter " + Convert.ToString(num_clusters) + " initial cluster centers separated by commas. \nNOTE: Enter the row number from csv sheet", "Cluster Centers", "");
                if (initial_cc == "")
                    invalid_input = "INVALID INPUT!\n";
            } while (initial_cc == "");

            iteration = 0;

            Y = new double[data_set_rows, data_set_attr];
            data_set = new double[data_set_rows, data_set_attr];
            cluster_centers = new double[num_clusters, data_set_attr];

            mean = new double[data_set_attr-1];
            variance = new double[data_set_attr-1];
            covariance_matrix = new double[data_set_attr - 1, data_set_attr - 1];     //Covariance matrix of feature vectors
            m_inverse = new double[data_set_attr - 1, data_set_attr - 1];             //Inverse of covariance matrix
        

            clusters = new int[num_clusters, data_set_rows];

            clusters_cnt = Enumerable.Repeat(0, num_clusters).ToArray();
            best_ideas = new int[num_clusters];
            meu = new double[data_set_rows, num_clusters];
            mahalanobis = new double[data_set_rows, num_clusters];
        }

        private void radbtnWINE_Click(object sender, EventArgs e)
        {
            data_set_rows = 178;
            data_set_attr = 14;
            num_clusters = 3;
            max_iteration = 20;
            taamjhaam_k = 20;
            fuzzy_index = 3;
            dataSetPath = "DataSets\\wine.csv";
            string invalid_input = "";
            initial_cc = "";
            do
            {
                initial_cc = Interaction.InputBox(invalid_input + "Enter " + Convert.ToString(num_clusters) + " initial cluster centers separated by commas. \nNOTE: Enter the row number from csv sheet", "Cluster Centers", "");
                if (initial_cc == "")
                    invalid_input = "INVALID INPUT!\n";
            } while (initial_cc == "");

            iteration = 0;

            Y = new double[data_set_rows, data_set_attr];
            data_set = new double[data_set_rows, data_set_attr];
            cluster_centers = new double[num_clusters, data_set_attr];

            mean = new double[data_set_attr-1];
            variance = new double[data_set_attr-1];
            covariance_matrix = new double[data_set_attr - 1, data_set_attr - 1];     //Covariance matrix of feature vectors
            m_inverse = new double[data_set_attr - 1, data_set_attr - 1];             //Inverse of covariance matrix
        

            clusters = new int[num_clusters, data_set_rows];

            clusters_cnt = Enumerable.Repeat(0, num_clusters).ToArray();
            best_ideas = new int[num_clusters];
            meu = new double[data_set_rows, num_clusters];
            mahalanobis = new double[data_set_rows, num_clusters];
        }

        private void radbtnDiabetes_Click(object sender, EventArgs e)
        {
            data_set_rows = 768;
            data_set_attr = 9;
            num_clusters = 2;
            max_iteration = 20;
            taamjhaam_k = 20;
            fuzzy_index = 3;
            dataSetPath = "DataSets\\diabetes.csv";
            string invalid_input = "";
            initial_cc = "";
            do
            {
                initial_cc = Interaction.InputBox(invalid_input + "Enter " + Convert.ToString(num_clusters) + " initial cluster centers separated by commas. \nNOTE: Enter the row number from csv sheet", "Cluster Centers", "");
                if (initial_cc == "")
                    invalid_input = "INVALID INPUT!\n";
            } while (initial_cc == "");

            iteration = 0;

            Y = new double[data_set_rows, data_set_attr];
            data_set = new double[data_set_rows, data_set_attr];
            cluster_centers = new double[num_clusters, data_set_attr];

            mean = new double[data_set_attr-1];
            variance = new double[data_set_attr-1];
            covariance_matrix = new double[data_set_attr - 1, data_set_attr - 1];     //Covariance matrix of feature vectors
            m_inverse = new double[data_set_attr - 1, data_set_attr - 1];             //Inverse of covariance matrix
        

            clusters = new int[num_clusters, data_set_rows];

            clusters_cnt = Enumerable.Repeat(0, num_clusters).ToArray();
            best_ideas = new int[num_clusters];
            meu = new double[data_set_rows, num_clusters];
            mahalanobis = new double[data_set_rows, num_clusters];
        }

        private void radbtnSGVP_Click(object sender, EventArgs e)
        {
            data_set_rows = 57;
            data_set_attr = 8;
            num_clusters = 3;
            max_iteration = 20;
            taamjhaam_k = 20;
            fuzzy_index = 3;
            dataSetPath = "DataSets\\sgvp.csv";
            string invalid_input = "";
            initial_cc = "";
            do
            {
                initial_cc = Interaction.InputBox(invalid_input + "Enter " + Convert.ToString(num_clusters) + " initial cluster centers separated by commas. \nNOTE: Enter the row number from csv sheet", "Cluster Centers", "");
                if (initial_cc == "")
                    invalid_input = "INVALID INPUT!\n";
            } while (initial_cc == "");

            iteration = 0;

            Y = new double[data_set_rows, data_set_attr];
            data_set = new double[data_set_rows, data_set_attr];
            cluster_centers = new double[num_clusters, data_set_attr];

            mean = new double[data_set_attr-1];
            variance = new double[data_set_attr-1];
            covariance_matrix = new double[data_set_attr - 1, data_set_attr - 1];     //Covariance matrix of feature vectors
            m_inverse = new double[data_set_attr - 1, data_set_attr - 1];             //Inverse of covariance matrix
        

            clusters = new int[num_clusters, data_set_rows];

            clusters_cnt = Enumerable.Repeat(0, num_clusters).ToArray();
            best_ideas = new int[num_clusters];
            meu = new double[data_set_rows, num_clusters];
            mahalanobis = new double[data_set_rows, num_clusters];
        }

        private void radbtnDUMMY_CheckedChanged(object sender, EventArgs e)
        {
            data_set_rows = 4;
            data_set_attr = 4;
            num_clusters = 2;
            max_iteration = 20;
            taamjhaam_k = 20;
            fuzzy_index = 3;
            dataSetPath = "DataSets\\dummy.csv";
            string invalid_input = "";
            initial_cc = "";
            do
            {
                initial_cc = Interaction.InputBox(invalid_input + "Enter " + Convert.ToString(num_clusters) + " initial cluster centers separated by commas. \nNOTE: Enter the row number from csv sheet", "Cluster Centers", "");
                if (initial_cc == "")
                    invalid_input = "INVALID INPUT!\n";
            } while (initial_cc == "");

            iteration = 0;

            Y = new double[data_set_rows, data_set_attr];
            data_set = new double[data_set_rows, data_set_attr];
            cluster_centers = new double[num_clusters, data_set_attr];

            mean = new double[data_set_attr - 1];
            variance = new double[data_set_attr - 1];
            covariance_matrix = new double[data_set_attr - 1, data_set_attr - 1];     //Covariance matrix of feature vectors
            m_inverse = new double[data_set_attr - 1, data_set_attr - 1];             //Inverse of covariance matrix
        

            clusters = new int[num_clusters, data_set_rows];

            clusters_cnt = Enumerable.Repeat(0, num_clusters).ToArray();
            best_ideas = new int[num_clusters];
            meu = new double[data_set_rows, num_clusters];
            mahalanobis = new double[data_set_rows, num_clusters];
        }

        private void chart4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void chart5_Click(object sender, EventArgs e)
        {

        }

        private void lblchart1dunn_Click(object sender, EventArgs e)
        {

        }

        private void chart6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }
    }
}
