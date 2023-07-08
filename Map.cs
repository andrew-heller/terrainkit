
//https://github.com/mono/SkiaSharp/blob/main/samples/Basic/NetCore/Console/SkiaSharpSample/Program.cs


using SkiaSharp;

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

     var info = new SKImageInfo(Size.WidthPixels(), Size.HeightPixels());
			using (var surface = SKSurface.Create(info))
			{
				// the the canvas and properties
				var canvas = surface.Canvas;

				// make sure the canvas is blank
				canvas.Clear(SKColors.White);

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
				canvas.DrawText("SkiaSharp", coord, paint);

				// save the file
				using (var image = surface.Snapshot())
				using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
				using (var stream = File.OpenWrite(filename))
				{
					data.SaveTo(stream);
				}
			}
		}
    
    
}

