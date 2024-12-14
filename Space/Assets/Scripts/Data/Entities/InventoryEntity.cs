using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Entities
{
    public class InventoryEntity
    {
        public string Id { get; set; }
        public string PlayerId { get; set; } 
        public List<string> Items { get; set; } = new List<string>();
    }
}