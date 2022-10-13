using Bonuses.BL.Model;
using System;
using System.Collections.Generic;

namespace Bonuses.BL.Controller
{
    public class DetectionController : ControllerBase
    {
        public DetectionController()
        {
            Detections = GetDetections();
        }

        public List<Detection> Detections { get; private set; }

        public void ReWrite(List<Detection> detections)
        {
            Detections = detections;
            Save();
        }

        private List<Detection> GetDetections()
        {
            return Load<Detection>() ?? new List<Detection>();
        }

        private void Save()
        {
            Save(Detections);
        }

        
    }
}
