//https://github.com/mono/SkiaSharp/blob/main/samples/Basic/NetCore/Console/SkiaSharpSample/Program.cs


public class Size{
    public int Width { get; set; }
    public int Depth {get;set;}
     public int Height {get;set;}

     public int WidthPixels(){
		return  Width * 100;
	 } 

     public int HeightPixels(){
		return  Height * 100;
	 } 
     
}

