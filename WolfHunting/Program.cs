using System;
using System.Collections.Generic;
using System.Linq;
using Mars.Interfaces.Model;
using WolfHunting.Model;
using WolfHunting.Model.Agents;
using WolfHunting.Model.Layers;

namespace WolfHunting
{
    class Program
    {
        static void Main(string[] args)
        {
            var description = new ModelDescription();
            description.AddLayer<ForestLayer>();
            description.AddAgent<Deer, ForestLayer>();
            description.AddAgent<Wolf, ForestLayer>();

        }
    }
}
