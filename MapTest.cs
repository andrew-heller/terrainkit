public static class MapTest{

    public static void TestCard1(){
    
        var sz = new Size(){
        Width=36, Height=48
        };

        var card = new MapCard(){
            DropZone = DropZoneType.top__bottom_full,
            ID ="Hammer",
            Objectives= new List<MapLocation>{
            new MapLocation(){
                    X=0,Y=0
            },
            new MapLocation(){
                    X=0,Y=20

            },
            new MapLocation(){
                    X=-16,Y=0
            },
            new MapLocation(){
                    X=16,Y=0
            },
            new MapLocation(){
                    X=0,Y=-20
            }}
        };
        
        //Build the map
        var mp = card.Build(sz);

        mp.Name=$"Test-{card.ID}-Card";
        //write map to file
        mp.ExportMapPNG($"{mp.Name}.png");

    }
}