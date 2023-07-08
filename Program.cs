using System.Collections.Generic;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Terrain Kit!");

 
var MyMap = new Map();

MyMap.Description ="MY FIRST TEST MAP";
MyMap.Name="Test";

MyMap.Zones.Add(new MapZone(){
      ZoneType = ZoneType.Deployment
}
);

MyMap.Zones.Add(new MapZone(){
      ZoneType = ZoneType.Deployment
}
);

MyMap.Zones.Add(new MapZone(){
      ZoneType = ZoneType.NoMansLand,
      Objective = new MapObjective()
}
);

Console.WriteLine($"Map \"{MyMap.Name}\" has {MyMap.Zones.Count} zones");

MyMap.ExportMapPNG("mymap.png");


//create a place to store a bunch of terrain objects
var TerrainList = new List<Terrain>();

//generate and add terrain object so the list
for(int x = 0; x < 20; x++){


   //generate random terrain
    var myruins = new Terrain();

    myruins.TerrainType = TerrainType.Barrier;

    TerrainList.Add(myruins);


}


foreach(var item in TerrainList){

Console.WriteLine($"My example terrain object : {item.TerrainType}");

}

