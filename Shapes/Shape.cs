


// classes are REFERENCE TYPES, numbers etc are Value Types
public class Shape {
   
    public ShapeType Type { get; set; }


    public SkiaSharp.SKPoint position {get;set;}

    //size of bounding box, width height
    public int Width {get;set;}
    public int Height {get;set;}

    //rotation, can size be used to determine rotation?
    public ShapeOrientation Orientation {get;set;}

}

