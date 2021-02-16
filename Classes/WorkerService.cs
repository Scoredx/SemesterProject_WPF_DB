using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SemesterProject_WPF_DB.Classes
{
    class WorkerService
    {
        Database1Entities1 db = new Database1Entities1();
        /// <summary>
        /// Create new worker entity in database
        /// </summary>
        /// <param name="worker"></param>
        public void NewWorker(worker worker)
        {
            db.worker.Add(worker);
            db.SaveChanges();
        }
        /// <summary>
        /// Select worker entity using worker index
        /// </summary>
        /// <param name="workerID">worker index</param>
        /// <returns>worker entity using worker index</returns>
        public worker SelectWorkerById(int workerID)
        {
            var worker_  = db.worker.FirstOrDefault(y => y.worker_id == workerID);
            return worker_;
        }
        /// <summary>
        /// Returns list of workers
        /// </summary>
        /// <returns>Returns list of workers</returns>
        public List<worker> GetList()
        {
            var list = db.worker.ToList();
            return list;
        }
        /// <summary>
        /// Removes worker entity from database
        /// </summary>
        /// <param name="worker">worker object</param>
        public void RemoveWorker(worker worker)
        {
            if (worker != null) db.worker.Remove(worker);
            db.SaveChanges();
        }
        /// <summary>
        /// Updates worker entity parameters
        /// </summary>
        /// <param name="workerObject">worker object</param>
        /// <param name="worker_name">worker name</param>
        /// <param name="worker_surname">worker surname</param>
        /// <param name="worker_pesel">worker pesel</param>
        public void UpdateWorker(worker workerObject, string worker_name,string worker_surname, string worker_pesel)
        {
            if (workerObject != null)
            {
                workerObject.worker_name = worker_name;
                workerObject.worker_surename = worker_surname;
                workerObject.worker_pesel = worker_pesel;
            }
            db.SaveChanges();
        }
    }
}
