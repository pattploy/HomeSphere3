using Google.Cloud.Firestore;
using System;


namespace HomeSphere2.Models
{
    public class RepairModel
    {
        [FirestoreProperty]
        public string RoomNo { get; set; }

        [FirestoreProperty]
        public string Option { get; set; }


        [FirestoreProperty]
        public string Detail { get; set; }
    }
}
