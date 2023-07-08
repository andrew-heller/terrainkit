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

		var canvas = surface.Canvas;
	
		var boxcolor = new SKPaint(){
			Color = SKColors.Pink
		};
		var tcolor= new SKPaint(){
			Color= SKColors.BlueViolet
		};

		var linecolor = new SKPaint(){
			Color = SKColors.Blue

		};
		var ucolor = new SKPaint(){
			Color = SKColors.SeaGreen

		};

		var lcolor = new SKPaint(){
			Color = SKColors.Chocolate

		};

		foreach(var shp in shapes){

		switch(shp.Type){

			case ShapeType.line:

				var endpt = new SKPoint(shp.position.X + shp.Width, shp.position.Y + shp.Height);

			 	canvas.DrawLine(shp.position,endpt,linecolor);

				break;
			case ShapeType.box: //is a line
				AddBox(shp,canvas,boxcolor);
				break;

			case ShapeType.t_shape:

				AddTShape(shp,canvas,tcolor);
				break;

			case ShapeType.l_shape:

				AddLShape(shp,canvas,lcolor);
				break;
			case ShapeType.u_shape:

				AddUShape(shp,canvas,ucolor);
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


public static void AddUShape(Shape shp, SKCanvas canvas, SKPaint tcolor){

//bounding box for shape
//turn single shage into 3 rects

		var isHorizontal = shp.Width > shp.Height ? true : false;
		
		if(isHorizontal){

		}

		var Longside = new Shape(){
			Width = shp.Width,
			Height = Size.InchesToPixelsMultiplier,
			Type = ShapeType.box,
			position= shp.position

		};

		var smallsideLeft = new Shape(){
			Type= ShapeType.box,
			Width = Size.InchesToPixelsMultiplier,
			Height = shp.Height,
			position= new SKPoint(shp.position.X,shp.position.Y)
		};

		var smallsideRight = new Shape(){
			Type= ShapeType.box,
			Width = Size.InchesToPixelsMultiplier,
			Height = shp.Height,
			position= new SKPoint(shp.position.X + shp.Width,shp.position.Y)
		};

		AddBox(Longside,canvas,tcolor);
		AddBox(smallsideLeft,canvas,tcolor);
		AddBox(smallsideRight,canvas,tcolor);




}

public static void AddLShape(Shape shp, SKCanvas canvas, SKPaint tcolor){

//bounding box for shape
//turn single shage into 3 rects

		var isHorizontal = shp.Width > shp.Height ? true : false;
		
		if(isHorizontal){

		}

		var Longside = new Shape(){
			Width = shp.Width,
			Height = Size.InchesToPixelsMultiplier,
			Type = ShapeType.box,
			position= shp.position

		};

		var smallsideLeft = new Shape(){
			Type= ShapeType.box,
			Width = Size.InchesToPixelsMultiplier,
			Height = shp.Height,
			position= new SKPoint(shp.position.X,shp.position.Y)
		};

	

		AddBox(Longside,canvas,tcolor);
		AddBox(smallsideLeft,canvas,tcolor);
		




}


public static void AddTShape(Shape shp, SKCanvas canvas, SKPaint tcolor){

		AddBox(shp,canvas,tcolor);
		var smallside = new Shape();
		smallside.Width = Size.InchesToPixelsMultiplier;
		smallside.Height = shp.Width;
		smallside.position= new SKPoint( (shp.position.X + shp.Width/2 ) - Size.InchesToPixelsMultiplier/2,shp.position.Y);
		AddBox(smallside,canvas,tcolor);

}

public static void AddBox(Shape shp,SKCanvas canvas,SKPaint boxcolor){
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