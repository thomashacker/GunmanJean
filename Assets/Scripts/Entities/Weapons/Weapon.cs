using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Weapon
{
    void trigger_primary();
    void trigger_secondary();

    void init_components(PlayerState _playerState);
}
