using System;
using System.Collections.Generic;
using TriInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "IconsConfig", menuName = "ScriptableObjects/IconsConfig")]
public class IconsConfig : ScriptableObject
{
    [TableList(HideAddButton = false, AlwaysExpanded = true)] public List<NamedIcon> OfferIcons;
    [TableList(HideAddButton = false, AlwaysExpanded = true)] public List<NamedIcon> OfferImages;
}

[Serializable]
public class NamedIcon
{
    [Required] public string Name;
    [Required] public Sprite Icon;
}