using Google.Cloud.Firestore;
using System;


namespace HomeSphere2.Models
{
    public class UserModel
    {
        [FirestoreProperty]
        public string RoomNo { get; set; }

        [FirestoreProperty]
        public string Date { get; set; }


        [FirestoreProperty]
        public string ParcelNo { get; set; }
    }
}
