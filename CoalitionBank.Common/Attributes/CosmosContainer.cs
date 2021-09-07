using System;

namespace CoalitionBank.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CosmosContainer : Attribute
    {
        public string Name { get; private set; }
        
        public string PartiotionKeyPath { get; private set; }

        public CosmosContainer(string name, string partiotionKeyPath = "/partitionKey")
        {
            Name = name;
            PartiotionKeyPath = partiotionKeyPath;
        }
    }
}