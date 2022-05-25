using Cinema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.ViewModel
{
    public class HallBoxSource
    {
        private static Core db = new Core();
        private static List<Seats> boxTable = db.context.Seats.ToList();

        public static List<Node> FillBoxNodeList(int parentId)
        {
            Node node;
            List<Node> resultBoxNodeList = new List<Node>();
            foreach (var item in boxTable.Where(x => x.ParentId == parentId).OrderBy(x => x.Number).ToList())
            {
                node = new Node()
                {
                    IdSeat = item.IdSeat,
                    Number = item.Number,
                    Description = item.Decription,
                    ParentId = item.ParentId ?? 0,
                    Nodes = FillBoxNodeList(item.IdSeat)
                };
                resultBoxNodeList.Add(node);

            }
            return resultBoxNodeList;
        }

    }
}
