using UnityEngine;
using System.Collections;

namespace RTS {
	public static class WorkManager {
		public static Rect CalculateSelectionBox(Bounds selectionBounds, Rect playingArea)
		{
			//shorthand for the coordinates of the centre of the selection bounds
			float cx = selectionBounds.center.x;
			float cy = selectionBounds.center.y;
			float cz = selectionBounds.center.z;

			//shorthand for the coordinates of the extents of the selection bounds
			float ex = selectionBounds.extents.x;
			float ey = selectionBounds.extents.y;
			float ez = selectionBounds.extents.z;
		}
	}
}
