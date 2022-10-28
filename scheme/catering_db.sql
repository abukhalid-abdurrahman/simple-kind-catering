CREATE TABLE client (
    id BIGSERIAL NOT NULL
            CONSTRAINT client_id_pk
                PRIMARY KEY,
    name VARCHAR (25) NOT NULL 
);


CREATE TABLE catering_point (
    id BIGSERIAL NOT NULL
            CONSTRAINT catering_point_id_pk
                PRIMARY KEY,
    name VARCHAR (25) NOT NULL 
);


CREATE TABLE client_catering_point (
    id BIGSERIAL NOT NULL
            CONSTRAINT catering_point_id_pk
                PRIMARY KEY,
    client_id INTEGER NOT NULL,
    catering_point_id INTEGER NOT NULL,
    day_of_week INTEGER NOT NULL,
    is_deleted BOOLEAN NOT NULL DEFAULT FALSE,
    CONSTRAINT fk_client
        FOREIGN KEY (client_id) 
            REFERENCES client(id),
    CONSTRAINT fk_catering_point
        FOREIGN KEY (catering_point_id) 
            REFERENCES catering_point(id)
);

CREATE UNIQUE INDEX client_id_idx on client (id);
CREATE UNIQUE INDEX catering_point_id_idx on catering_point (id);
CREATE UNIQUE INDEX client_catering_point_id_idx on client_catering_point (id);