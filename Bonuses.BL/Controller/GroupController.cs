using Bonuses.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bonuses.BL.Controller
{
    public class GroupController : ControllerBase
    {
        public GroupController()
        {
            Group = GetGroup();
        }

        public Group Group { get; set; }

        public event EventHandler OnNameChanged;

        public void Change(Group group)
        {
            Group = group;
            Save();
            OnNameChanged?.Invoke(Group, null);
        }

        private Group GetGroup()
        {
            List<Group> groups = Load<Group>();
            return groups.Count > 0 ? groups.First() : new Group();
        }

        private void Save()
        {
            Save(new List<Group>() { Group });
        }
    }
}
