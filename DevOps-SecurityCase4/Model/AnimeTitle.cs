using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOps_SecurityCase4.Model
{
    class AnimeTitle : BaseModel
    {
        private string title;

        public string Title
        {
            get { return title; }

            set
            {
                title = value;
                NotifyPropertyChanged();
            }
        }
    }
}
