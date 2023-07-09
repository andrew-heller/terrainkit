
//https://github.com/mono/SkiaSharp/blob/main/samples/Basic/NetCore/Console/SkiaSharpSample/Program.cs


using SkiaSharp;


public enum DropZoneType{
	top__bottom_full,
	top_bottom_half,
	diagonal_corners
}

// settings passed to MAP to be used to build it...
public class MapCard{
	
	public string ID {get;set;}
	//configure the dropzones
	public DropZoneType DropZone {get;set;}

	//configure the objectives
	public List<MapLocation> Objectives {get;set;}

	//0 to 100, 0 = no terrain, 100 is entire map has terrain
	public int TerrainDensity {get;set;}

	//terrian type weights


}
public class ObjectivePosition{
	
	public MapLocation OffsetFromCenter {get;set;}
}



public class Map{

    
    //constructor
    //initialize any reference type properties
    public Map(){

            Zones = new List<MapZone>();
            //default to 3x5
            Size = new Size(){
                Width=36,
                Height=60
            };

    }

	public MapCard Card {get;set;}

    public List<MapZone> Zones {get;set;}

	//used as filename for export
    public string? Name {get;set;}
    public string? Description {get;set;}

    public Size Size {get;set;}

    public void GenerateTerrain(){

        //rules on how to generate terrain

        //look at all the zones


    }




    public void ExportMapPNG(string filename){


//define image size
     var info = new SKImageInfo(Size.WidthPixels(), Size.HeightPixels());
			using (var surface = SKSurface.Create(info))
			{
				// the the canvas and properties
				var canvas = surface.Canvas;

				// make sure the canvas is blank
				canvas.Clear(SKColors.White);

				//draw a inch grid
				ImageDrawGrid(info,canvas,SKColors.Green);
				
// draw some text
var paint = new SKPaint
				{
					Color = SKColors.Black,
					IsAntialias = true,
					Style = SKPaintStyle.Fill,
					TextAlign = SKTextAlign.Center,
					TextSize = 24
				};
				var coord = new SKPoint(info.Width / 2, (info.Height + paint.TextSize) / 2);
				//draw text
				canvas.DrawText(this.Description, coord, paint);


				// save the file
				using (var image = surface.Snapshot())
				using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
				using (var stream = File.OpenWrite(filename))
				{
					data.SaveTo(stream);
				}
			}
		}
    
    public void ImageDrawGrid(SKImageInfo info,SKCanvas canvas, SKColor color){

var paint = new SKPaint
				{
					Color = color,
					IsAntialias = true,
					Style = SKPaintStyle.Fill,
					TextAlign = SKTextAlign.Center,
					TextSize = 24
				};

				
				//draw grid
				var origin = new SKPoint(0,0); //upperleft corner
				var bottompoint = new SKPoint(0,info.Height);
				for(int x = 0; x<= info.Width; x+=Size.InchesToPixelsMultiplier){
				
					origin.X = x;
					bottompoint.X = x;

					canvas.DrawLine(origin,bottompoint,paint);

				}
				//reset back to zero
				origin.X=0;
				bottompoint.X=info.Width;
				for(int y = 0; y<= info.Height; y+=Size.InchesToPixelsMultiplier){
				
					origin.Y = y;
					bottompoint.Y = y;

					canvas.DrawLine(origin,bottompoint,paint);

				}
	}
}

