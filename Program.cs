using System;
using System.Collections.Generic;
using System.Linq;

namespace ArtificialIntelligenceSnake
{
   enum snakePositionType {

      ATCORNERUPL=0,
     ATCORNERDOWNL =1,
      TSHAPEUP=2,
      TSHAPEDOWN =3,
      ALLFREEUP=4,
      ALLFREEDOWN=5,
      ATCORNERDOWNR=6,
      ATCORNERUPR=7,

      ATCORNERL=8,
      ATCORNERR=9,

      INVALID = 10

    }
 public class Point
{
    public Point(int posX, int posY)
    {
        PosX = posX;
        PosY = posY;
    }

    public int PosX { get; set; }
    public int PosY { get; set; }

    public double DistanceFromPoint(Point otherPoint)
    {
        return Math.Sqrt(Math.Pow((otherPoint.PosX - PosX), 2) + Math.Pow((otherPoint.PosY - PosY), 2));
    }
}
public class SnakeXenzia
{
  
    int[,] _boardDimention;
    int[,] _snakePosition;
    int[,] _targetPosition;

     int _actualRowSnake =0;
  int _actualColSnake =0;
    int _actualRowBoard =0;
  int _actualColBoard =0;

  int _totalMoves =0;
  int _minmum=0;
   public SnakeXenzia(int[,] dimention,int[,] target,int[,] snakePosition){

     

  this._boardDimention=dimention;
this._targetPosition=target;
this._snakePosition = snakePosition;
   }



void printPossibleMoves(List<Point>  moves,int type){
  Console.WriteLine($"Possible moves for {Enum.GetName(typeof(snakePositionType), type)} length {moves.Count} are");

foreach(Point x  in moves)
Console.WriteLine($"{x.PosX},{x.PosY}");

}

    List<Point>   getPossibleMoves(int position,int accRowSnake,int accColSnake ){
 
    List<Point> points = new List<Point>();
  
switch(position)
     {

    case (short) snakePositionType.ATCORNERDOWNL:


 points = new List<Point>
    {
        new Point(accRowSnake-1, accColSnake),
        new Point(accRowSnake,accColSnake+1),
    };


  printPossibleMoves(points,(int)snakePositionType.ATCORNERDOWNL);

 
    break;

     case (short) snakePositionType.ATCORNERUPL:
   

    points = new List<Point>
    {
        new Point(accRowSnake+1,accColSnake),
        new Point(accRowSnake,accColSnake+1)

    };



 printPossibleMoves(points,(int)snakePositionType.ATCORNERUPL);
    
    break;



  case (short) snakePositionType.ATCORNERUPR:
   
  points = new List<Point>
    {
        new Point(_snakePosition.GetLength(0)+1,_snakePosition.GetLength(1)),
        new Point(_snakePosition.GetLength(0),_snakePosition.GetLength(1)-1),
    };

 

    printPossibleMoves(points,(int)snakePositionType.ATCORNERUPR);
    
    break;

 case (short) snakePositionType.ATCORNERDOWNR:
   

     points = new List<Point>
    {
        new Point(_snakePosition.GetLength(0)-1,_snakePosition.GetLength(1)),
        new Point(_snakePosition.GetLength(0),_snakePosition.GetLength(1)-1),
    };



    printPossibleMoves(points,(int)snakePositionType.ATCORNERDOWNR);
    
   
    
    break;


      case (short) snakePositionType.TSHAPEDOWN:
   

   points = new List<Point>
    {
        new Point(_snakePosition.GetLength(0)-1,_snakePosition.GetLength(1)),
        new Point(_snakePosition.GetLength(0),_snakePosition.GetLength(1)-1),
            new Point(_snakePosition.GetLength(0),_snakePosition.GetLength(1)+1)
    };
        


      printPossibleMoves(points,(int)snakePositionType.TSHAPEDOWN);
     
    
    break;


      case (short) snakePositionType.TSHAPEUP:
   


  points = new List<Point>
    {
        new Point(_snakePosition.GetLength(0)+1,_snakePosition.GetLength(1)),
        new Point(_snakePosition.GetLength(0),_snakePosition.GetLength(1)-1),
            new Point(_snakePosition.GetLength(0),_snakePosition.GetLength(1)+1)
    };
           


      printPossibleMoves(points,(int)snakePositionType.TSHAPEUP);
     
    
    break;

     case (short) snakePositionType.ALLFREEUP:
     
      case (short) snakePositionType.ALLFREEDOWN:
   
   
     points = new List<Point>
    {
        new Point(_snakePosition.GetLength(0)+1,_snakePosition.GetLength(1)),
        new Point(_snakePosition.GetLength(0)-1,_snakePosition.GetLength(1)),
            new Point(_snakePosition.GetLength(0),_snakePosition.GetLength(1)-1),
              new Point(_snakePosition.GetLength(0),_snakePosition.GetLength(1)+1)
    };

  
       printPossibleMoves(points,(int)snakePositionType.ALLFREEDOWN);
     
     
    
    break;



       case (short) snakePositionType.ATCORNERL:
   

      points = new List<Point>
    {
     
                 new Point(_snakePosition.GetLength(0)+1,_snakePosition.GetLength(1)),
        new Point(_snakePosition.GetLength(0)-1,_snakePosition.GetLength(1)),
            new Point(_snakePosition.GetLength(0),_snakePosition.GetLength(1)+1)
    };



   
       printPossibleMoves(points,(int)snakePositionType.ATCORNERL);
     
    
    break;

        case (short) snakePositionType.ATCORNERR:


  points = new List<Point>
    {
        new Point(_snakePosition.GetLength(0)+1,_snakePosition.GetLength(1)),
        new Point(_snakePosition.GetLength(0)-1,_snakePosition.GetLength(1)),
            new Point(_snakePosition.GetLength(0),_snakePosition.GetLength(1)-1)
              
    };
 


      printPossibleMoves(points,(int)snakePositionType.ATCORNERR);
     
    
    
    break;

   

}



  


return points;
    }


    bool isIndexExists(int[,] target,int[,] dimention){


if(target.GetLength(0)<=dimention.GetLength(0) && target.GetLength(1)<=dimention.GetLength(1)){
return true;
}

return false;
}

int[,] getRandomPositionOnBoard(){
     Random random = new Random();
 int _row = random.Next(0, _boardDimention.GetLength(0));
 int _col = random.Next(0,_boardDimention.GetLength(1));
 return new int[_row,_col];
}

short getSnakePositionType(){

   _actualRowSnake = _snakePosition.GetLength(0)>=0?_snakePosition.GetLength(0)-1:_snakePosition.GetLength(0) ;
   _actualColSnake = _snakePosition.GetLength(1)>=0?_snakePosition.GetLength(1)-1:_snakePosition.GetLength(1);
     _actualRowBoard = _boardDimention.GetLength(0)>=0?_boardDimention.GetLength(0)-1:_boardDimention.GetLength(0);
   _actualColBoard = _boardDimention.GetLength(1)>=0?_boardDimention.GetLength(1)-1:_boardDimention.GetLength(1);
  _minmum=0;
 short currentPos=(short)snakePositionType.INVALID;

  //AT CORNER UP L
    if((_actualRowSnake-1)<_minmum&&(_actualColSnake-1)<_minmum){
return 0;
    }
  


     //AT CORNER DOWN L
    if  (((_actualRowSnake+1)>_actualRowBoard)&&((_actualColSnake-1)<_minmum))
    {
       return 1;
    }

    //T SHAPE UP
   if((_actualRowSnake-1)<_minmum &&(_actualColSnake+1<=_actualColBoard)&&(_actualColSnake-1<=_actualColBoard)){

return 2;
   }
//T SHAPE DOWN
 if((_actualRowSnake+1)>_actualRowBoard &&(_actualColSnake+1<=_actualColBoard)&&(_actualColSnake-1<=_actualColBoard)){

return 3;
   }
 

 //ALL FREE UP
    if((_actualRowSnake-1)<=_minmum &&(_actualColSnake-1<=_minmum)&&(_actualColSnake+1>=_actualColBoard))

    {
       return 4;
    }
       //ALL FREE DOWN
     if((_actualRowSnake+1)<=_actualRowBoard &&(_actualColSnake-1>=_minmum)&&(_actualColSnake+1<=_actualColBoard))

    {
      return 5;
    }
  //AT CORNER DOWN R
    if  (((_actualRowSnake+1)>_actualRowBoard)&&((_actualColSnake+1)>_actualColBoard))
    {
        return 6;
    }

  //AT CORNER UP R
    if((_actualRowSnake-1)<_minmum&&(_actualColSnake+1)>_actualColBoard){
return 7;
    }
  


   



int a = (_actualRowSnake-1),b = _minmum,c = _actualColSnake+1;
 //ATCORNERL
    if((_actualRowSnake-1)>=_minmum &&(_actualColSnake+1<=_actualColBoard))

    {
       return 8;
    }
  
 //ATCORNERR
    if((_actualRowSnake-1)>=_minmum &&(_actualColSnake-1>=_actualColBoard-1))

    {
       return  9;
    }


   return currentPos;
  
}


 Point getNearFromTarget( List<Point> possiblePosition){
 Point closestPoint=null; 
 if(isSuccess())
{
Console.WriteLine("Snake has been captured");

}
else{
 if(possiblePosition.Count>0){
  
   closestPoint = possiblePosition.OrderBy(point => 
   point.DistanceFromPoint(new Point(_targetPosition.GetLength(0),_targetPosition.GetLength(1))
   )).FirstOrDefault();

  Console.WriteLine($"The closest point to {_targetPosition.GetLength(0)},{_targetPosition.GetLength(1)} is {closestPoint.PosX},{closestPoint.PosY}");
Console.WriteLine($"Moving snake to {closestPoint.PosX},{closestPoint.PosY}");


  }
}

 
return closestPoint;


  }






void moveSnake(Point point)
{
  if(point!=null)
  {
_snakePosition = new int[point.PosX,point.PosY];
Console.WriteLine($"Snake moved to {point.PosX},{point.PosY}");
_totalMoves++;
  }

else
{
    Console.WriteLine("No path to move");
}
}

bool isValidLoop(){

  if(_snakePosition.GetLength(0)>_boardDimention.GetLength(0)||_snakePosition.GetLength(1)>_boardDimention.GetLength(1))
  return false;

  else
  //Console.WriteLine($"invalid position {_snakePosition.GetLength(0)},{_snakePosition.GetLength(1)}");
  return true;

}
bool isSuccess(){
return (  _snakePosition.GetLength(0)==_targetPosition.GetLength(0)&&_snakePosition.GetLength(1)==_targetPosition.GetLength(1));
}
public void runGame(){
 
if(isSuccess())
{
Console.WriteLine("Snake has been captured");
Console.WriteLine($"Total moves = {_totalMoves}");
return;
}


  else{
     List<Point> point=null;
     if(isIndexExists(_targetPosition,_boardDimention)&&isValidLoop())
{


short _type = getSnakePositionType();

switch(_type){

    case (short) snakePositionType.ATCORNERDOWNL:
  Console.WriteLine("Snake is to the corner Down L");

 point=getPossibleMoves(((int)snakePositionType.ATCORNERDOWNL),_snakePosition.GetLength(0),_snakePosition.GetLength(1));

    break;

     case (short) snakePositionType.ATCORNERUPL:
   
Console.WriteLine("Snake is to the corner Up L");
   
   point= getPossibleMoves(((int)snakePositionType.ATCORNERUPL),_snakePosition.GetLength(0),_snakePosition.GetLength(1));

    break;



  case (short) snakePositionType.ATCORNERUPR:
   
Console.WriteLine("Snake is to the corner Up R");
  point= getPossibleMoves(((int)snakePositionType.ATCORNERUPR),_snakePosition.GetLength(0),_snakePosition.GetLength(1));

    
    break;

 case (short) snakePositionType.ATCORNERDOWNR:
   
Console.WriteLine("Snake is to the corner Down R");
   
  point=  getPossibleMoves(((int)snakePositionType.ATCORNERDOWNR),_snakePosition.GetLength(0),_snakePosition.GetLength(1));

    break;


      case (short) snakePositionType.TSHAPEDOWN:
   
Console.WriteLine("Snake is T Shape Down");
   
 point=   getPossibleMoves(((int)snakePositionType.TSHAPEDOWN),_snakePosition.GetLength(0),_snakePosition.GetLength(1));

    break;


      case (short) snakePositionType.TSHAPEUP:
   
Console.WriteLine("Snake is T Shape UP");
 point=  getPossibleMoves(((int)snakePositionType.TSHAPEUP),_snakePosition.GetLength(0),_snakePosition.GetLength(1));

    
    break;

     case (short) snakePositionType.ALLFREEUP:
   
Console.WriteLine("Snake is ALL FREE UP");
point=   getPossibleMoves(((int)snakePositionType.ALLFREEUP),_snakePosition.GetLength(0),_snakePosition.GetLength(1));

    
    break;


      case (short) snakePositionType.ALLFREEDOWN:
   
Console.WriteLine("Snake is ALL FREE DOWN");
   
 point=   getPossibleMoves(((int)snakePositionType.ALLFREEDOWN),_snakePosition.GetLength(0),_snakePosition.GetLength(1));

    break;

       case (short) snakePositionType.ATCORNERL:
   
Console.WriteLine("Snake is AT CORNER LEFT");
point=   getPossibleMoves(((int)snakePositionType.ATCORNERL),_snakePosition.GetLength(0),_snakePosition.GetLength(1));

    
    break;

        case (short) snakePositionType.ATCORNERR:
   
Console.WriteLine("Snake is AT CORNER RIGHT");
point=   getPossibleMoves(((int)snakePositionType.ATCORNERR),_snakePosition.GetLength(0),_snakePosition.GetLength(1));

    
    break;
default:
Console.WriteLine("Snake is lost!");
break;
   

}

moveSnake(getNearFromTarget(point));
}
  }
   
runGame();
}


}

    class Program
    {



        static void Main(string[] args)
        {


Console.WriteLine("Welcome to xenzia!");


  Random random  = new Random();
 int boardRow = 1, boardCol =1,targetRow=1,targetCol=1,snakePosX=1,snakePosY=1;



Console.WriteLine("Enter board rows:");
boardRow = int.Parse(Console.ReadLine());

Console.WriteLine("Enter board columns:");
boardCol = int.Parse(Console.ReadLine());



Console.WriteLine("Enter target row:");
targetRow = int.Parse(Console.ReadLine());



Console.WriteLine("Enter target column:");
targetCol = int.Parse(Console.ReadLine());


Console.WriteLine("Enter snake row:");
snakePosX = int.Parse(Console.ReadLine());


Console.WriteLine("Enter snake column:");
snakePosY = int.Parse(Console.ReadLine());



  SnakeXenzia game = new SnakeXenzia(new int[boardRow,boardCol],new int[targetRow,targetCol],new int[ snakePosX, snakePosY]);
game.runGame();

        
    
        }
    }
}
