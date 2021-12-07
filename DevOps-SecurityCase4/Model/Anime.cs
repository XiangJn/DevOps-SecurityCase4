using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOps_SecurityCase4.Model
{
    class Anime : BaseModel
    {
        private int id;
        private string title;
        private string status;



        public int ID
        {
            get { return id; }

            set
            {
                id = value;
                NotifyPropertyChanged();
            }
        }

        public string Title
        {
            get { return title; }

            set
            {
                title = value;
                NotifyPropertyChanged();
            }
        }

        public string Status
        {
            get { return status; }

            set
            {
                status = value;
                NotifyPropertyChanged();
            }
        }
    

 
    }
}
