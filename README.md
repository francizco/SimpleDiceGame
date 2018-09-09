# SimpleDiceGame

This is a simple dice game that uses a 5-sided die. There are numerous ways of scoring for this game, but two specific methods.  
  
The first method takes the category and the roll and returns the score.
  
The second method returns a list categories that score the highest given a roll.  
  
### Scoring Categories

Ones – scores the sum of all the ones  
Twos – scores the sum of all the twos  
Threes – scores the sum of all the threes  
Fours – scores the sum of all the fours  
Fives – scores the sum of all the fives  
Sixes – scores the sum of all the sixes  
Sevens – scores the sum of all the sevens  
Eights – scores the sum of all the eights  
ThreeOfAKind – scores the sum of all dice if there are 3 or more of the same die, otherwise scores 0  
FourOfAKind – scores the sum of all dice if there are 4 or more of the same die, otherwise scores 0  
AllOfAKind – Scores 50 if all of the dice are the same, otherwise scores 0  
NoneOfAKind – Scores 40 if there are no duplicate dice, otherwise scores 0  
FullHouse – Scores 25 if there are two duplicate dice of one value and three duplicate dice of a different value, otherwise scores 0  
SmallStraight – Scores 30 if there are 4 or more dice in a sequence, otherwise scores 0  
LargeStraight – Scores 40 if all 5 dice are in a sequence, otherwise scores 0
Chance – scores the sum of all dice  

## Getting Started

Everything to test and run the example is included here.

### Prerequisites

Originally created in Visual Studio 2017 for Windows.

### Installing

Clone and open in your favorite editor.

## Future Modifications

The Dice and Scorer classes are tightly coupled. Will be fixing this in a later update by making a Dice interface.

## Author

* **Frank Fuentes**

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
