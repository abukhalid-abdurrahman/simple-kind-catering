CREATE OR REPLACE FUNCTION catering_change_by_client_history_fn (
        client_id_in BIGINT
    )
    RETURNS TABLE (
        created_at DATE,
        name VARCHAR (25),
        event TEXT
        ) AS
$Body$
    SELECT ccch.created_at,
           c.name,
           ccch.event
    FROM client_catering_change_history ccch
    JOIN client c on ccch.client_id = c.id
    WHERE c.id = client_id_in;
$Body$
LANGUAGE sql;

CREATE OR REPLACE FUNCTION client_change_by_catering_history_fn (
        catering_id_in BIGINT
    )
    RETURNS TABLE (
        created_at DATE,
        name VARCHAR (25),
        event TEXT
        ) AS
$Body$
    SELECT ccch.created_at,
           cp.name,
           ccch.event
    FROM client_catering_change_history ccch
    JOIN catering_point cp on ccch.catering_point_id = cp.id
    WHERE cp.id = catering_id_in;
$Body$
LANGUAGE sql;

CREATE OR REPLACE FUNCTION client_change_by_catering_history_all_fn ()
    RETURNS TABLE (
        created_at DATE,
        name VARCHAR (25),
        event TEXT
        ) AS
$Body$
    SELECT ccch.created_at,
           cp.name,
           ccch.event
    FROM client_catering_change_history ccch
    JOIN catering_point cp on ccch.catering_point_id = cp.id;
$Body$
LANGUAGE sql;

CREATE OR REPLACE FUNCTION catering_change_by_client_history_all_fn ()
    RETURNS TABLE (
        created_at DATE,
        name VARCHAR (25),
        event TEXT
        ) AS
$Body$
    SELECT ccch.created_at,
           c.name,
           ccch.event
    FROM client_catering_change_history ccch
    JOIN client c on ccch.client_id = c.id;
$Body$
LANGUAGE sql;