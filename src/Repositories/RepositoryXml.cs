using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

using HomeworkOrganiser.API.Models;

namespace HomeworkOrganiser.API.Repositories
{
    /// <summary>
    /// XML Repository.
    /// </summary>
    public class RepositoryXml<T> : Repository<T> where T : EntityBase
    {
        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeworkOrganiser.API.Repositories.XmlRepository`1"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public RepositoryXml(string fileName)
        {
            FileName = fileName;
            Load();
        }

        /// <summary>
        /// Add the specified entity.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public override void Add(T entity)
        {
            base.Add(entity);
            Save();
        }

        /// <summary>
        /// Remove the specified entity.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public override void Remove(T entity)
        {
            base.Remove(entity);
            Save();
        }

        /// <summary>
        /// Save this instance.
        /// </summary>
        public void Save()
        {
            FileStream fs;

            if (File.Exists(FileName))
            {
                fs = new FileStream(FileName, FileMode.Open, FileAccess.Write);
            }
            else
            {
                fs = File.Create(FileName);
            }

            using (StreamWriter sw = new StreamWriter(fs))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Dictionary<string, T>));
                xs.Serialize(sw, DataStore);
            }
        }

        /// <summary>
        /// Load this instance.
        /// </summary>
        public void Load()
        {
            if (!File.Exists(FileName))
                return;

            XmlSerializer xs = new XmlSerializer(typeof(List<T>));

            using (FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs))
            {
                DataStore = (Dictionary<string, T>)xs.Deserialize(sr);
            }
        }
    }
}
