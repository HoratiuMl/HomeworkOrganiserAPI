using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

using HomeworkOrganiserAPI.Models;

namespace HomeworkOrganiserAPI.DAL.Repositories
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
        /// Initializes a new instance of the <see cref="HomeworkOrganiserAPI.DAL.Repositories.XmlRepository`1"/> class.
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
        /// Remove the specified entity.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public override void Remove(string id)
        {
            base.Remove(id);
            Save();
        }

        /// <summary>
        /// Save this instance.
        /// </summary>
        public void Save()
        {
            FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
            List<T> entities = new List<T>(DataStore.Values);
            
            using (StreamWriter sw = new StreamWriter(fs))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<T>));
                xs.Serialize(sw, entities);
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
            List<T> entities;

            using (FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs))
            {
                entities = (List<T>)xs.Deserialize(sr);
            }

            DataStore = entities.ToDictionary(E => E.Id, E => E);
        }
    }
}
