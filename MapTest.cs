public static class MapTest{

    public static void TestCard1(){
    
        var sz = new Size(){
                Width=48, Height=48
        };

        var card = new MapCard(){
            DropZone = DropZoneType.top__bottom_full,
            ID ="Hammer",
            Objectives= new List<MapObjective>()
        };

//offset from center lines
var circlesize = 20; //pixels

        card.Objectives.Add( new MapObjective(){
                 Offset = new Size(){
                        X = 0,
                        Y = 0,
                        Width= circlesize
                 }
        });
        card.Objectives.Add( new MapObjective(){
                 Offset = new Size(){
                        X = 16,
                        Y = 0,
                        Width= circlesize
                 }
        });
        card.Objectives.Add( new MapObjective(){
                 Offset = new Size(){
                        X = -16,
                        Y = 0,
                        Width= circlesize
                 }
        });
        card.Objectives.Add( new MapObjective(){
                 Offset = new Size(){
                        X = 0,
                        Y = 20,
                        Width= circlesize
                 }
        });
        card.Objectives.Add( new MapObjective(){
                 Offset = new Size(){
                        X = 0,
                        Y = -20,
                        Width= circlesize
                 }
        });


        //Build the map
        var mp = card.Build(sz);

        mp.Name=$"Test-{card.ID}-Card";
        //write map to file
        mp.ExportMapPNG($"{mp.Name}.png");

    }
}