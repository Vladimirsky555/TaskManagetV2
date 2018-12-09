using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagetV2.Model
{
    class TextRecord
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public Guid Owner { get; set; }

        public TextRecord ()
        {
            //TODO доделать конструктор
        }
    }
}
