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

    List<Point>   getPossibleMoves(int position,int accRowSnake,int accColSnake,int accRowBoard,int accColBoard ){
 
    List<Point> points = new List<Point>();
switch(position)
     {

    case (short) snakePositionType.ATCORNERDOWNL:


 points = new List<Point>
    {
        new Point(accRowSnake-1, accColSnake),
        new Point(accRowSnake,accColBoard+1),
    };


  printPossibleMoves(points,(int)snakePositionType.ATCORNERDOWNL);

 
    break;

     case (short) snakePositionType.ATCORNERUPL:
   

    points = new List<Point>
    {
        new Point(accRowSnake+1,accColSnake),
        new Point(accRowSnake,accRowSnake+1),
    };



 printPossibleMoves(points,(int)snakePositionType.ATCORNERUPL);
    
    break;



  case (short) snakePositionType.ATCORNERUPR:
   
  points = new List<Point>
    {
        new Point(accRowSnake+1,accColSnake),
        new Point(accRowSnake,accColSnake-1),
    };

 

    printPossibleMoves(points,(int)snakePositionType.ATCORNERUPR);
    
    break;

 case (short) snakePositionType.ATCORNERDOWNR:
   

     points = new List<Point>
    {
        new Point(accRowSnake-1,accColSnake),
        new Point(accRowSnake,accColSnake-1),
    };



    printPossibleMoves(points,(int)snakePositionType.ATCORNERDOWNR);
    
   
    
    break;


      case (short) snakePositionType.TSHAPEDOWN:
   

   points = new List<Point>
    {
        new Point(accRowSnake-1,accColSnake),
        new Point(accRowSnake,accColSnake-1),
            new Point(accRowSnake,accColSnake+1)
    };
        


      printPossibleMoves(points,(int)snakePositionType.TSHAPEDOWN);
     
    
    break;


      case (short) snakePositionType.TSHAPEUP:
   


  points = new List<Point>
    {
        new Point(accRowSnake+1,accColSnake),
        new Point(accRowSnake,accColSnake-1),
            new Point(accRowSnake,accColSnake+1)
    };
           


      printPossibleMoves(points,(int)snakePositionType.TSHAPEUP);
     
    
    break;

     case (short) snakePositionType.ALLFREEUP:
     
      case (short) snakePositionType.ALLFREEDOWN:
   
   
     points = new List<Point>
    {
        new Point(accRowSnake+1,accColSnake),
        new Point(accRowSnake-1,accColSnake),
            new Point(accRowSnake,accColBoard-1),
              new Point(accRowSnake,accColSnake+1)
    };

  
       printPossibleMoves(points,(int)snakePositionType.ALLFREEDOWN);
     
     
    
    break;



       case (short) snakePositionType.ATCORNERL:
   
      points = new List<Point>
    {
        new Point(accRowSnake+1,accColSnake),
        new Point(accRowSnake-1,accColSnake),
            new Point(accRowSnake,accColSnake+1)
              
    };



   
       printPossibleMoves(points,(int)snakePositionType.ATCORNERL);
     
    
    break;

        case (short) snakePositionType.ATCORNERR:


  points = new List<Point>
    {
        new Point(accRowSnake+1,accColSnake),
        new Point(accRowSnake-1,accColSnake),
            new Point(accRowSnake,accColSnake-1)
              
    };
 


      printPossibleMoves(points,(int)snakePositionType.ATCORNERR);
     
    
    
    break;

   

}



 getNearFromTarget(points);


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

   _actualRowSnake = _snakePosition.GetLength(0)-1;
   _actualColSnake = _snakePosition.GetLength(1)-1;
     _actualRowBoard = _boardDimention.GetLength(0)-1;
   _actualColBoard = _boardDimention.GetLength(1)-1;
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
 if(isSuccess(_snakePosition))
{
Console.WriteLine("Already capture");

}
else{
 if(possiblePosition.Count>0){
  
   closestPoint = possiblePosition.OrderBy(point => 
   point.DistanceFromPoint(new Point(_targetPosition.GetLength(0),_targetPosition.GetLength(1))
   )).FirstOrDefault();

  Console.WriteLine($"The closest point to {_targetPosition.GetLength(0)},{_targetPosition.GetLength(1)} is {closestPoint.PosX},{closestPoint.PosY}");

  }
}

 
return closestPoint;


  }








bool isValidLoop(){

  if(_snakePosition.GetLength(0)>_boardDimention.GetLength(0)||_snakePosition.GetLength(1)>_boardDimention.GetLength(1))
  return false;

  else
  //Console.WriteLine($"invalid position {_snakePosition.GetLength(0)},{_snakePosition.GetLength(1)}");
  return true;

}
bool isSuccess(int[,] snakePos){
return (  snakePos.GetLength(0)==_targetPosition.GetLength(0)&&snakePos.GetLength(1)==_targetPosition.GetLength(1));
}
public void runGame(){
if(isSuccess(_snakePosition))
{
Console.WriteLine("Already capture");
return;
}
  else{
     if(isIndexExists(_targetPosition,_boardDimention)&&isValidLoop())
{


short _type = getSnakePositionType();
switch(_type){

    case (short) snakePositionType.ATCORNERDOWNL:
  Console.WriteLine("Snake is to the corner Down L");

 getPossibleMoves(((int)snakePositionType.ATCORNERDOWNL),_actualRowSnake,_actualColSnake,_actualRowBoard,_actualColBoard);

    break;

     case (short) snakePositionType.ATCORNERUPL:
   
Console.WriteLine("Snake is to the corner Up L");
   
    getPossibleMoves(((int)snakePositionType.ATCORNERUPL),_actualRowSnake,_actualColSnake,_actualRowBoard,_actualColBoard);

    break;



  case (short) snakePositionType.ATCORNERUPR:
   
Console.WriteLine("Snake is to the corner Up R");
   getPossibleMoves(((int)snakePositionType.ATCORNERUPR),_actualRowSnake,_actualColSnake,_actualRowBoard,_actualColBoard);

    
    break;

 case (short) snakePositionType.ATCORNERDOWNR:
   
Console.WriteLine("Snake is to the corner Down R");
   
    getPossibleMoves(((int)snakePositionType.ATCORNERDOWNR),_actualRowSnake,_actualColSnake,_actualRowBoard,_actualColBoard);

    break;


      case (short) snakePositionType.TSHAPEDOWN:
   
Console.WriteLine("Snake is T Shape Down");
   
    getPossibleMoves(((int)snakePositionType.TSHAPEDOWN),_actualRowSnake,_actualColSnake,_actualRowBoard,_actualColBoard);

    break;


      case (short) snakePositionType.TSHAPEUP:
   
Console.WriteLine("Snake is T Shape UP");
   getPossibleMoves(((int)snakePositionType.TSHAPEUP),_actualRowSnake,_actualColSnake,_actualRowBoard,_actualColBoard);

    
    break;

     case (short) snakePositionType.ALLFREEUP:
   
Console.WriteLine("Snake is ALL FREE UP");
   getPossibleMoves(((int)snakePositionType.ALLFREEUP),_actualRowSnake,_actualColSnake,_actualRowBoard,_actualColBoard);

    
    break;


      case (short) snakePositionType.ALLFREEDOWN:
   
Console.WriteLine("Snake is ALL FREE DOWN");
   
    getPossibleMoves(((int)snakePositionType.ALLFREEDOWN),_actualRowSnake,_actualColSnake,_actualRowBoard,_actualColBoard);

    break;

       case (short) snakePositionType.ATCORNERL:
   
Console.WriteLine("Snake is AT CORNER LEFT");
   getPossibleMoves(((int)snakePositionType.ATCORNERL),_actualRowSnake,_actualColSnake,_actualRowBoard,_actualColBoard);

    
    break;

        case (short) snakePositionType.ATCORNERR:
   
Console.WriteLine("Snake is AT CORNER RIGHT");
   getPossibleMoves(((int)snakePositionType.ATCORNERR),_actualRowSnake,_actualColSnake,_actualRowBoard,_actualColBoard);

    
    break;
default:
Console.WriteLine("Snake is lost!");
break;
   

}
}
  }
   

}


}

    class Program
    {



        static void Main(string[] args)
        {

        for(int row=1;row<=4;row++){

for(int col=1;col<=4;col++)
{
  SnakeXenzia game = new SnakeXenzia(new int[4,4],new int[2,2],new int[row,col]);
game.runGame();
}
        }
    
        }
    }
}
