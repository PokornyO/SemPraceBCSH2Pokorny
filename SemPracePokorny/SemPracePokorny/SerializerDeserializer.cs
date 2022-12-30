using LiteDB;
using SemPracePokorny.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemPracePokorny
{
    class SerializerDeserializer
    {
        private ObservableCollection<Pobocka> pobocky;
        private string fileName;

        public SerializerDeserializer(ObservableCollection<Pobocka> pobocky, string fileName)
        {
            this.pobocky = pobocky;
            this.fileName = fileName;
        }
        public void Save()
        {

            using(var db = new LiteDatabase(fileName))
            {
                db.DropCollection("pobocky");
                var col = db.GetCollection<Pobocka>("pobocky");
                
                foreach(Pobocka p in pobocky)
                {
                    col.Insert(p);
                }
                var result = col.Query().ToList();
            }
        }
        public void Load()
        {
            
            using (var db = new LiteDatabase(fileName))
            {
                var col = db.GetCollection<Pobocka>("pobocky");
                var result = col.Query().ToList();          
                foreach(Pobocka p in result) {
                    pobocky.Add(p);
                }
                
            }
        }
    }
}
