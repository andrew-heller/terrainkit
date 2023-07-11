//https://github.com/mono/SkiaSharp/blob/main/samples/Basic/NetCore/Console/SkiaSharpSample/Program.cs


// settings passed to MAP to be used to build it...
public class MapCard{
	
	public string ID {get;set;}
	//configure the dropzones
	public DropZoneType DropZone {get;set;}

	//configure the objectives
	public List<MapObjective> Objectives {get;set;}

	//0 to 100, 0 = no terrain, 100 is entire map has terrain
	public int TerrainDensity {get;set;}

	//terrian type weights
	
public  Map Build(Size mapsize){

	//build zones
	var map = new Map();
	map.Size = mapsize;
	map.Zones = new List<MapZone>();

	//get center point of map
	var center = new MapLocation();
	center.X = mapsize.Width/2;
	center.Y = mapsize.Height/2;

	var dropzoneA = new MapZone();
	dropzoneA.ZoneType = ZoneType.DeploymentA;

	//bottom dropzone
	var dropzoneB = new MapZone();
	dropzoneA.ZoneType = ZoneType.DeploymentB;

	var nomanzone = new MapZone();
	nomanzone.ZoneType = ZoneType.NoMansLand;

    map.Zones.Add(dropzoneA);
    map.Zones.Add(dropzoneB);
    map.Zones.Add(nomanzone);
    
	map.Objectives= this.Objectives;

		//dropzone is 12 from center
		if(DropZone == DropZoneType.top__bottom_full){
			
            //top dropzone
            var zoneoffset = 12;
            var zonewidth = map.Size.Width;
            var zoneheight = (map.Size.Height / 2) - zoneoffset;
            
            dropzoneA.Location.Width = zonewidth;
            dropzoneA.Location.Height = zoneheight;
            
            //same size as zoneA
            dropzoneB.Location.Width = zonewidth;
            dropzoneB.Location.Height = zoneheight;
            
            nomanzone.Location.Width = zonewidth;
            nomanzone.Location.Height = zoneoffset * 2;
            /*..............*/
            dropzoneA.Location.X=0;
            dropzoneA.Location.Y=0;
            /*
            no mans land
             */
            nomanzone.Location.X=0;
            nomanzone.Location.Y= dropzoneA.Location.Height;

            dropzoneB.Location.X=0;
            dropzoneB.Location.Y= dropzoneA.Location.Height + nomanzone.Location.Height;

		}

	
	//

	return map;


	}
	
}

