using System;
using Google.Cloud.Firestore;
using HomeSphere2.Models;


namespace HomeSphere2.Services
{
    public class FirestoreService
    {
        private FirestoreDb db;
        public string StatusMessage;

        public FirestoreService()
        {
            this.SetupFireStore();
        }

        private async Task SetupFireStore()
        {
            if (db == null)
            {
                var stream = await FileSystem.OpenAppPackageFileAsync("homesphere-adaf3-firebase-adminsdk-rs81k-08697c105e.json");
                var reader = new StreamReader(stream);
                var contents = reader.ReadToEnd();
                db = new FirestoreDbBuilder
                {
                    ProjectId = "homesphere-adaf3",

                    JsonCredentials = contents
                }.Build();
            }
        }

        public async Task<List<RepairModel>> GetAllRepair()
        {
            try
            {
                await SetupFireStore();
                var data = await db.Collection("Repair").GetSnapshotAsync();
                var repairs = data.Documents.Select(doc =>
                {
                    var repair = new RepairModel();
                    repair.RoomNo = doc.GetValue<string>("RoomNo");
                    repair.Option = doc.GetValue<string>("Option");
                    repair.Detail = doc.GetValue<string>("Detail");
                    return repair;
                }).ToList();
                return repairs;
            }
            catch (Exception ex)
            {

                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        public async Task InsertRepair(RepairModel repair)
        {
            try
            {
                await SetupFireStore();
                var repairData = new Dictionary<string, object>
            {
                { "RoomNo", repair.RoomNo },
                { "Option", repair.Option },
                { "Detail", repair.Detail }
                // Add more fields as needed
            };

                await db.Collection("Repair").AddAsync(repairData);
            }
            catch (Exception ex)
            {

                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public async Task UpdateRepair(RepairModel repair)
        {
            try
            {
                await SetupFireStore();

                // Manually create a dictionary for the updated data
                var repairData = new Dictionary<string, object>
            {
                { "RoomNo", repair.RoomNo },
                { "Option", repair.Option },
                { "Detail", repair.Detail }
                // Add more fields as needed
            };

                // Reference the document by its Id and update it
                var docRef = db.Collection("Repair").Document(repair.RoomNo);
                await docRef.SetAsync(repairData, SetOptions.Overwrite);

                StatusMessage = "Repair successfully updated!";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        internal async Task<IEnumerable<object>> GetAllParcel()
        {
            throw new NotImplementedException();
        }

        //parcel

        public async Task<List<UserModel>> GetAllUser()
        {
            try
            {
                await SetupFireStore();
                var data = await db.Collection("Parcel").GetSnapshotAsync();
                var users = data.Documents.Select(doc =>
                {
                    var user = new UserModel();
                    user.RoomNo = doc.GetValue<string>("RoomNo");
                    user.Date = doc.GetValue<string>("Date");
                    user.ParcelNo = doc.GetValue<string>("ParcelNo");
                    return user;
                }).ToList();
                return users;
            }
            catch (Exception ex)
            {

                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }


    }
}

