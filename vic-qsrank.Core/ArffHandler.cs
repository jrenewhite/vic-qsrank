using ArffTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace vic_qsrank.Core
{
    public class ArffHandler
    {
        public ArffHeader Header { get; set; }
        public object[][] Instances { get; set; }
        public bool Verbose { get; protected set; }

        /// <summary>
        /// Prevents initialization without a file
        /// </summary>
        protected ArffHandler()
        {

        }

        /// <summary>
        /// Handles an arff file
        /// </summary>
        /// <param name="arff"></param>
        public ArffHandler(string arff, bool verbose)
        {
            Verbose = verbose;
            ReadArff(arff);
        }

        /// <summary>
        /// Reads an arff file and gets all the headers (<see cref="ArffHeader"/>) and instances (<see cref="object[][]"/>).
        /// </summary>
        /// <param name="arff">Arff file name</param>
        private void ReadArff(string arff)
        {
            Header = null;
            Instances = null;
            try
            {
                if (File.Exists(arff))
                {
                    using (ArffReader arffReader = new ArffReader(arff))
                    {
                        Header = arffReader.ReadHeader();
                        Instances = arffReader.ReadAllInstances();
                    }
                }
                else
                {
                    throw new FileNotFoundException(string.Format("File \"{0}\" does not exist.", arff), arff);
                }
            }
            catch (Exception e)
            {
                if (Verbose)
                {
                    throw new Exception(string.Format("Arff file could not be read: {0}\n{1}", e.Message, e.StackTrace), e);
                }
                else
                {
                    throw new Exception(string.Format("Arff file could not be read: {0}", e.Message), e);
                }
            }
        }

        /// <summary>
        /// Creates an <see cref="ArffReader"/> instance
        /// </summary>
        /// <param name="arff">Arff file name</param>
        /// <returns>
        /// An <see cref="ArffReader"/> instance
        /// </returns>
        private ArffReader CreateArffReader(string arff)
        {
            if (Verbose)
            {
                Console.WriteLine("Reading arff file \"{0}\".", arff);
            }
            MemoryStream memoryStream = new MemoryStream();
            using (StreamWriter streamWriter = new StreamWriter(memoryStream, Encoding.UTF8, 4096, true))
            {
                streamWriter.Write(arff);
            }
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new ArffReader(memoryStream);
        }
    }
}
