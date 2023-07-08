using SkiaSharp;

public static class DrawingHelper{


    public static void WritePNG(SKSurface surface,string filename){

// save the file
				using (var image = surface.Snapshot())
				using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
				using (var stream = File.OpenWrite(filename))
				{
					data.SaveTo(stream);
				}
    }


public static SKSurface CreateSurface(SKImageInfo info){
	return  SKSurface.Create(info);
}


public static void DrawShapes(SKSurface surface, List<Shape> shapes){

		// the the canvas and properties
		var canvas = surface.Canvas;

		// make sure the canvas is blank
		//canvas.Clear(SKColors.White);

		//draw a inch grid
	
		var boxcolor = new SKPaint(){
			Color = SKColors.Red
		};
		var tcolor= new SKPaint(){
			Color= SKColors.Cornsilk
		};

		var linecolor = new SKPaint(){
			Color = SKColors.Blue

		};

		foreach(var shp in shapes){

		switch(shp.Type){

			case ShapeType.line:

			var endpt = new SKPoint(shp.position.X + shp.Width, shp.position.Y + shp.Height);

			 canvas.DrawLine(shp.position,endpt,linecolor);
			break;
			case ShapeType.box: //is a line
			//get point
			//create path
			AddRect(shp,canvas,boxcolor);
			
		
				
			break;

			case ShapeType.t_shape:

			AddRect(shp,canvas,tcolor);
			var smallside = new Shape();
			smallside.Width = Size.InchesToPixelsMultiplier;
			smallside.Height = shp.Width;
			smallside.position= new SKPoint( (shp.position.X + shp.Width/2 ) - Size.InchesToPixelsMultiplier/2,shp.position.Y);
			AddRect(smallside,canvas,tcolor);




		
			break;
			default:
			//show text?
			break;
		}


}

				
// draw some text
// var paint = new SKPaint
// 				{
// 					Color = SKColors.Black,
// 					IsAntialias = true,
// 					Style = SKPaintStyle.Fill,
// 					TextAlign = SKTextAlign.Center,
// 					TextSize = 24
// 				};
				//var coord = new SKPoint(info.Width / 2, (info.Height + paint.TextSize) / 2);
				//draw text
				//canvas.DrawText(this.Description, coord, paint);


				
			}

public static void AddRect(Shape shp,SKCanvas canvas,SKPaint boxcolor){
	var pth = new SKPath();
			var rec = new SKRect();
				rec.Top = shp.position.Y;
				rec.Left = shp.position.X;
				rec.Right = rec.Left + shp.Width;
				rec.Bottom = rec.Top + shp.Height;
				
			pth.AddRect(rec);
			canvas.DrawPath(pth,boxcolor);
		

}

public static SKImageInfo CreateImage(int width, int height)
{
     //define image size
     var info = new SKImageInfo(width, height);

            return info;
}
    
public static void DrawGrid(SKImageInfo info,SKSurface surface, SKColor color){

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

				surface.Canvas.DrawLine(origin,bottompoint,paint);

			}
			//reset back to zero
			origin.X=0;
			bottompoint.X=info.Width;

			for(int y = 0; y<= info.Height; y+=Size.InchesToPixelsMultiplier){
			
				origin.Y = y;
				bottompoint.Y = y;

				surface.Canvas.DrawLine(origin,bottompoint,paint);

			}
	}
}