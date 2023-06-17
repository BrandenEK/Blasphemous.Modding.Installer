using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlasModInstaller
{
    [Serializable]
    public class Skin
    {
        public string id;
        public string name;
        public string author;
        public string DownloadURL { get; set; }

        public void UpdateLocalData(Skin globalSkin)
        {
            id = globalSkin.id;
            name = globalSkin.name;
            author = globalSkin.author;
        }

        public override bool Equals(object obj)
        {
            if (obj is Skin skin)
                return name == skin.name;
            return base.Equals(obj);
        }
    }
}
