
//https://github.com/mono/SkiaSharp/blob/main/samples/Basic/NetCore/Console/SkiaSharpSample/Program.cs


using SkiaSharp;

public class Map{

    
    //constructor
    //initialize any reference type properties
    public Map(){

            Zones = new List<MapZone>();
            //default to 3x5
            Size = new Size(){
                Width=48,
                Height=48
            };

    }

	///public MapCard Card {get;set;}

    public List<MapZone> Zones {get;set;}

	//used as filename for export
    public string? Name {get;set;}
    public string? Description {get;set;}

    public Size Size {get;set;}
    public List<MapObjective> Objectives { get; internal set; }

    public void ExportMapPNG(string filename){

      var paints = new List<SKPaint>(){
			
		 new SKPaint(){
			Color = SKColors.LightPink
		},
             new SKPaint(){
			Color = SKColors.LightBlue
		},
             new SKPaint(){
			Color = SKColors.White
		},
             new SKPaint(){
			Color = SKColors.Black, 
            Style = SKPaintStyle.Stroke,
            StrokeWidth=4
		}
        
        
        };


		//convert map to shapes
        var shapes = new List<Shape>();

        //add zones
        foreach (var zone in this.Zones){
                shapes.Add(new Shape(){
                    Type= ShapeType.box,
                    position = new SkiaSharp.SKPoint(zone.Location.XPixels(), zone.Location.YPixels()),
                    Width = zone.Location.WidthPixels(),
                    Height= zone.Location.HeightPixels(),
                    PaintIndex = zone.ZoneType == ZoneType.DeploymentA ? 0 :
                     zone.ZoneType == ZoneType.DeploymentB ? 1 : 2
                    }


                    );
        }

        //add objectives to map

        var center = new Size(){
            X = this.Size.Width/2,
            Y = this.Size.Height/2
            
        };

    foreach (var obj in this.Objectives){
                shapes.Add(new Shape(){
                    Type= ShapeType.Circle,
                    position = new SkiaSharp.SKPoint(center.XPixels() + obj.Offset.XPixels(),
                    center.YPixels() + obj.Offset.YPixels()),
                    Width = obj.Offset.Width,  //for circle this is in pixedl
                    //Height= obj.Offset.HeightPixels(),
                    PaintIndex = 3
                    }


                    );
        }


        var img = DrawingHelper.CreateImage(Size.WidthPixels(), Size.HeightPixels());

        using(var sfc = DrawingHelper.CreateSurface(img)){
            //set a global background color
            sfc.Canvas.Clear(SKColors.WhiteSmoke);

            DrawingHelper.DrawShapes(sfc ,shapes, paints);

            DrawingHelper.DrawGrid(img,sfc, SKColors.LightGray,1);
            DrawingHelper.DrawGrid(img,sfc, SKColors.Gray,6);
            DrawingHelper.DrawGrid(img,sfc, SKColors.Black,12);
            
            DrawingHelper.WritePNG(sfc,filename);    
        }
    
	}
}

