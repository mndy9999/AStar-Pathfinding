# AStar-v2

Implementation of the A* pathfinding algorithm I wrote as part of my Artificial Intelligence module. 

It was implemented by using nodes to represent different positions on the map.

The map can consist of multiple types of terrain, each of them having an associated cost:
  1. Road - move cost 1
  2. Grass - move cost 3
  3. Swamp - move cost 5
  4. Mountain - cannot be traversed
  5. Water - cannot be traversed
  
  
Mountains Only:
![Mountains Only](https://github.com/mndy9999/AStar-v2/blob/master/mountains_only.png)

Dead End:
![Dead End](https://github.com/mndy9999/AStar-v2/blob/master/dead_end.png)

Custom Map:
![Custom Map](https://github.com/mndy9999/AStar-v2/blob/master/path.png)
