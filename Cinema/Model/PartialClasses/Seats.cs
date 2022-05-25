using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Model
{
    public partial class Seats
    {
        //private static Core db = new Core();
        //private static List<Seats> seatsArray = db.context.Seats.ToList();

        //public int NumberRow = seatsArray.Where(x => x.ParentId == 0);
        public string NumberDescription => Number + " " + Decription;
     //   public int NumberSeat;

     //   private static Core db = new Core();
     //   private static List<Seats> arrayRowSeats = db.context.Seats.Where(x=>x.ParentId==0).ToList();
     //   private static List<Seats> arraySeats = db.context.Seats.ToList();
     //   public 
     //   foreach (var item in arrayRowSeats)
	    //{

	    //}

    }
}
