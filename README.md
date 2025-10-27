# Model.RestAPI

Some Early Thoughts on the Construction of this Project:

### Use PostgreSQL with JSONB

## Tables:

### Main Tables

#### Sports:

table of all sports present in DB

- sport_id (PK)

#### Leagues:

represents a governing body of competition

- league_id (PK)
- sport_id (FK from sports)
- name, abbreviation, level

#### LeagueHierarchies:

self referencing table to model structure of leagues (conferences, divisions)

- hierarchy_id (PK)
- league_id (FK)
- parent_id (FK to LeagueHierarchies)
- name

#### Persons:

table for players and coaches (to prevent data duplication)

- person_id (PK)
- first_name, last_name, birth_date, nationality
- physical_attributes - JSON for height, weight, etc

#### Teams:

representing teams / franchises as a whole

- team_id (PK)
- official_name, short_name

#### Venues:

stadiums

- venue_id (PK)
- name, city, state, capacity, location (coords)

#### Seasons:

a competitive year for a league

- season_id (PK)
- league_id (FK)
- year, type (regular season vs post season)

### Relationships and Junction Tables

#### TeamSeasonDetails:

one to many between Teams and Seasons

- team_season_id (PK)
- team_id (FK), season_id (FK)
- name_at_time, home_venue_id (FK)

#### Rosters:

many to many between Persons and TeamSeasonDetails

- roster_id (PK)
- person_id (FK), team_season_id (FK)
- role (Head Coach, Position Coach, Player), jersey_number, status (Active, Practice Squad, IR)

#### Games:

Links components together, stores statistical information

- game_id (PK)
- season_id (FK), venue_id (FK)
- game_datetime, status

#### GameParticipants:

many to many table between games and teams

- game_participant_id (PK)
- game_id (FK), team_season_id (FK)
- location, final_score

#### PlayerGameStats:

stores individual player statistics for a single game.

- player_game_stat_id (PK)
- game_id (FK), person_id (FK), team_season_id (FK)
- stats - JSONB column containing json data of stats

#### TeamGameStats:

stores aggregated team stats for a single game

- team_game_stat_id (PK)
- game_id (FK), team_season_id (FK)
- stats - JSONB column containing json data of stats