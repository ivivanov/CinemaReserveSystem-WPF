using CinemaReserve.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfExam.Helpers
{
    public class RedirectToReserveViewSuccessArgs: EventArgs
    {
        public int ProjectionId { get; set; }

        private ProjectionDetailsModel projection;

        public ProjectionDetailsModel Projection
        {
            get { return projection; }
            set { projection = value; }
        }


        public RedirectToReserveViewSuccessArgs(int projectionId):base()
        {
            this.ProjectionId = projectionId;
            this.Projection = Data.DataPersister.getProjectionById(this.ProjectionId);
        }
    }
}
