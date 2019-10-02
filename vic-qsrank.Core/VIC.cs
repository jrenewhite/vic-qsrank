using System;
using System.Collections;

namespace vic_qsrank.Core
{
    /// <summary>
    /// VIC algorithm
    /// </summary>
    public class VIC
    {
        /*
         * The process to compute VIC relies on three main components. First, a clustering algorithm, Ω,
         * which takes as an input an unlabeled dataset, D. Ω outputs a partition with k groups, where
         * all the objects in D belong to a cluster. Second, an ensemble of distinct supervised classifiers,
         * Ψ, which uses the given objects and class labels in a labeled dataset, T, to train a diverse set of
         * classifiers. Upon usage, a trained ensemble can assign a class label to a previously unseen object.
         * Third, a classification performance measure which is used to evaluate how good a classifier is,
         * whether ensemble or not when predicting the class labels of unseen objects.
         */
        /*
        * First, we run a given clustering algorithm
        * on a given unlabeled dataset, D, to calculate the partition of the data. Then, we construct
        * a labeled dataset, T, with all the objects in D, where the cluster indexes of the partition are
        * used to represent the class labels. Next, with the purpose of using n-fold cross-validation for
        * statistical validity, we separate T into n subsets of the same size, Z1,...,Zn, by using random
        * sampling without replacement. For each fold, we train an ensemble, Ψ, with the objects and
        * their corresponding class labels on T \Zi, and calculate the performance of the trained classifier
        * on Zi. Finally, the average of the classification performance of all folds is computed. The
        * average represents the computed value of VIC for the given dataset and clustering algorithm.
        */


        /// <summary>
        /// D:
        /// Dataset to be analized
        /// </summary>
        public object Dataset { get; protected set; }

        /// <summary>
        /// Ψ:
        /// Ensemble of supervised classifiers
        /// </summary>
        public IEnumerable Classifiers { get; set; }

        /// <summary>
        /// Ω:
        /// A clustering algorithm
        /// </summary>
        public object ClusteringAlgorithm { get; set; }

        public VIC(object dataset, IEnumerable classifiers, object clusteringAlgorithm)
        {
            Dataset = dataset;
            Classifiers = classifiers;
            ClusteringAlgorithm = clusteringAlgorithm;
        }

        protected VIC()
        {

        }

        //𝐷: dataset; Ψ: set of supervised classifiers; Ω : a clustering algorithm
        //Execute Ω  on 𝐷 to compute the set of clusters 𝑃 = {𝐶_1, 𝐶_2, . . . ,𝐶_𝑘}.
        //Create a dataset 𝑇 with all the objects in 𝐷; where every object is labeled with the index of the cluster 𝐶_𝑖∈𝑃 to which the object belongs.
        //Randomly divide 𝑇 into n subsets 𝑍_1, 𝑍_2, . . . ,𝑍_n of size |𝑇|/5 each.
        //Initialize the resulting index 𝑣 <- 0.

        /// <summary>
        /// Compute Clusters:
        /// A clustering algorithm, Ω, which takes as an input an unlabeled dataset, D.
        /// Ω outputs a partition with k groups, where all the objects in D belong to a cluster.
        /// </summary>
        private void ComputeClusters()
        {

        }

        /// <summary>
        /// Train Classifiers:
        /// An ensemble of distinct supervised classifiers, Ψ, which uses the given objects and 
        /// class labels in a labeled dataset, T, to train a diverse set of classifiers.
        /// </summary>
        /// <remarks>
        /// A trained ensemble can assign a class label to a previously unseen object.
        /// </remarks>
        private void TrainClassifiers()
        {

        }

        /// <summary>
        /// Classifier Performance Measurement:
        /// A classification performance measure which is used to evaluate how good a classifier is, 
        /// whether ensemble or not when predicting the class labels of unseen objects
        /// </summary>
        private void ClassifierPerformanceMeasurement()
        {
        }
    }
}
