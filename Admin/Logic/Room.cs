using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Admin.Logic
{
    class Room
    {
        public int RoomID { get; set; }
        public string RoomName { get; set; }

        public Room()
        {
        }

        public Room(int roomID, string roomName)
        {
            RoomID = roomID;
            RoomName = roomName;
        }
    }

    class RoomList
    {
        public static List<Room> GetAllRoom()
        {
            List<Room> cats = new List<Room>();
            DataTable dt = Project.Database.GetDataBySQL("SELECT * FROM dbo.[Room]");
            foreach (DataRow dr in dt.Rows)
                cats.Add(new Room(
                    Convert.ToInt32(dr["id"]),
                    dr["roomName"].ToString()
                    ));
            return cats;
        }
    }
}
