using System;
using System.Collections.Generic;
using UnityEngine;

namespace Application
{
    [Serializable]
    public class ListsData
    {
        [SerializeField]
        public List<ListData> Lists = new List<ListData>();
    }
}
