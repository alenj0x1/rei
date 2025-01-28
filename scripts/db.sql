create table worlds (
  world_id serial primary key not null,
  name varchar(100) not null unique,
  description text not null default('ups!, without a description'),
  updated_at timestamptz not null default(now()),
  created_at timestamptz not null default(now())
);

create table materials (
  material_id serial primary key not null,
  name varchar(100) not null unique,
  description varchar(300) not null default('ups!, without a description'),
  updated_at timestamptz not null default(now()),
  created_at timestamptz not null default(now())
);

create table materials_location (
  material_location_id serial primary key not null,
  material_id int not null references materials(material_id),
  world_id int not null references materials(material_id)
);
