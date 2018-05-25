using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ResolverProblemas : MonoBehaviour, IPointerClickHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler {
	RawImage sprite;
	Color target = Color.white;
	public GameObject Spawner;
	bool dragged = false;
	public int pos;
	Vector3 initPos;

	void Awake()
	{
		sprite = GetComponent<RawImage>();
	}

	void Start(){
		initPos = new Vector3 (this.transform.localPosition.x,this.transform.localPosition.y,0f);
	}

	void Update()
	{
		if (sprite)
			sprite.color = Vector4.MoveTowards(sprite.color, target, Time.deltaTime * 10);
	}

	public void OnPointerClick(PointerEventData eventData) // 3
	{
		//print("I was clicked");
		//target = Color.blue;
	}

	public void OnDrag(PointerEventData eventData)
	{
		//print("I'm being dragged!");
		target = Color.red;
		dragged = true;
		if (this.transform.localRotation.eulerAngles.z == 90) {
			this.transform.Translate (eventData.delta.x,eventData.delta.y, 0f,Space.World);
		} else {
			this.transform.Translate (eventData.delta.x, eventData.delta.y, 0f);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		target = Color.green;
	}

	public void OnPointerExit (PointerEventData eventData)
	{
		target = Color.white;
		if (dragged) {
			for (int i = 0; i < 44; i++) {
				float sx = Spawner.transform.GetChild (i).GetComponent<RectTransform> ().localPosition.x;
				float sy = Spawner.transform.GetChild (i).GetComponent<RectTransform> ().localPosition.y;
				if (this.transform.localPosition.x >= sx - 25f && this.transform.localPosition.x <= sx + 25f) {
					if (this.transform.localPosition.y >= sy - 25f && this.transform.localPosition.y <= sy + 25f) {
						initPos = new Vector3 (sx, sy, 0f);
						this.transform.localPosition = new Vector3 (sx, sy, 0f);
						pos = i;
					} else {
						//this.transform.localPosition = initPos;
					}
				} else {
					//this.transform.localPosition = initPos;
				}
			}
		}
		dragged = false;
		if (eventData.dragging == false) {
			this.transform.localPosition = initPos;
		}
	}

	public void SetPos(int p)
	{
		pos = p;
	}
	public int GetPos(){
		return pos;
	}
}
