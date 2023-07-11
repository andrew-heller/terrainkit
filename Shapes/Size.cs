//https://github.com/mono/SkiaSharp/blob/main/samples/Basic/NetCore/Console/SkiaSharpSample/Program.cs


public class Size{
    
    public const int InchesToPixelsMultiplier = 40;

    public int X {get;set;}
    public int Y {get;set;}

    public int Width { get; set; }
    public int Depth {get;set;}
     public int Height {get;set;}

     public int WidthPixels(){
		return  Width * InchesToPixelsMultiplier;
	 } 

     public int HeightPixels(){
		return  Height * InchesToPixelsMultiplier;
	 } 
     
     public int XPixels(){
		return  X * InchesToPixelsMultiplier;
     }
	 public int YPixels(){
		return  Y * InchesToPixelsMultiplier;
	 } 
}

