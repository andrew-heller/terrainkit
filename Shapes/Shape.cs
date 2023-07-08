


// classes are REFERENCE TYPES, numbers etc are Value Types
public class Shape {
   
    public ShapeType Type { get; set; }

    //size of bounding box the shape is in
    public Size BoundingBox {get;set;}

    public SkiaSharp.SKPoint position {get;set;}

    //rotation, can size be used to determine rotation?
    public ShapeOrientation Orientation {get;set;}

}

