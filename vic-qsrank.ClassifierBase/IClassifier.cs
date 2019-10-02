using ArffTools;
using System.Drawing;

namespace vic_qsrank.ClassifierBase
{
    public interface IClassifier
    {
        /// <summary>
        /// Name of the classifier
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Description of the classifier
        /// </summary>
        string Description { get; }

        Color MainColor { get; }

        Color VerboseColor { get; }

        int Execute(ArffHeader headers, object[][] instances);
    }
}
