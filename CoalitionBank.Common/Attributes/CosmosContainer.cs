using System;

namespace CoalitionBank.Common.Attributes
{
    public class CosmosContainer : Attribute
    {
        public string Name { get; private set; }
        
        public string PartiotionKeyPath { get; private set; }

        public CosmosContainer(string name, string partiotionKeyPath = "/PartitionKey")
        {
            Name = name;
            PartiotionKeyPath = partiotionKeyPath;
        }
    }
}