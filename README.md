# Snake-2D
A classic Snake game built in Unity, featuring additional mechanics like power-ups, dynamic food effects, and a competitive co-op multiplayer mode. Players compete against each other in the co-op mode, where one player’s snake can eliminate the other by biting it. This game captures the nostalgic feel of the old keypad Snake game while adding exciting new twists and challenges.
### Features
<ol>
<li><b>Movement:</b> The snake moves in all four directions (⬆️ ⬇️ ⬅️➡️).</li>
<li><b>Screen Wrapping:</b> The snake wraps around the screen edges.</li>
<li><b>Snake Growth:</b> The snake grows after consuming food.</li>
<li><b>Self-Collision:</b> The snake dies upon biting itself.</li>
</ol>

## Power-Ups:
<ol>
<li><b>Shield:</b> Protects the snake from death for a short time.</li>
<li><b>Score Boost:</b> Doubles the score gained when active.</li>
<li><b>Speed Up:</b> Temporarily increases the snake's speed.</li>
</ol>

### Cooldown for Power-Ups:
<ul>
  <li>Each power-up has a customizable cooldown (default is 3 seconds).</li>
</ul>

### Power-Up Spawning:
<ul>
  <li>Power-ups spawn randomly on the screen after random intervals of time.</li>
</ul>

### Food Mechanics:
<ol>
<li><b>Mass Gainer:</b> Increases the snake’s length when consumed.</li>
<li><b>Mass Burner:</b> Decreases the snake’s length (doesn't spawn if the snake is already small).</li>
<li><b>Food Lifespan:</b> Food disappears after a certain time if not eaten.</li>
<li><b>Length Flexibility:</b> The amount by which the snake grows or shrinks can be customized.</li>
</ol>

### Co-Op Mode:
<ul>
  <dl>
  <dt><li>Each power-up has a customizable cooldown (default is 3 seconds).</li></dt>
   <ul>
    <li><dd>Player 1 controls a snake using WASD.</dd></li>
     <li><dd>Player 2 controls another snake using the arrow keys (⬆️ ⬇️ ⬅️➡️).</dd></li>
     <li><dd>If one snake bites another, the bitten snake dies.</dd></li>
   <li> <dd>If both snakes heads collide while eating, the snake with the smaller length dies.</dd></li>
   </ul>
</ul>

### Scoring:
<ol>
<li>Eating <b>Mass Gainer</b> food increases the score.</li>
<li>Eating <b>Mass Burner</b> food decreases the score.</li>
</ol>

### UI:
<ol>
<li><b>Basic UI:</b> Includes death screens, win conditions, score displays, and lobby screens.</li>
<li><b>Game Controls:</b> Pause/Resume, Restart, and Quit buttons are implemented.</li>
</ol>
