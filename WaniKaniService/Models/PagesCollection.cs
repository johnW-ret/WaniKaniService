using System.Collections;

namespace WaniKaniService.Models;

public class PagesCollection<T> : IEnumerable<Resource<T>>, IEnumerable, ICollection<CollectionResponse<T>>
{
    private List<CollectionResponse<T>> collectionResponses = new List<CollectionResponse<T>>();

    public int Count => ((ICollection<CollectionResponse<T>>)collectionResponses).Count;

    public bool IsReadOnly => ((ICollection<CollectionResponse<T>>)collectionResponses).IsReadOnly;

    IEnumerator<Resource<T>> IEnumerable<Resource<T>>.GetEnumerator()
    {
        return (IEnumerator<Resource<T>>)GetEnumerator();
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)GetEnumerator();
    }

    public PagesCollectionEnumerator<T> GetEnumerator()
    {
        return new PagesCollectionEnumerator<T>(collectionResponses);
    }

    public void Add(CollectionResponse<T> item)
    {
        ((ICollection<CollectionResponse<T>>)collectionResponses).Add(item);
    }

    public void Clear()
    {
        ((ICollection<CollectionResponse<T>>)collectionResponses).Clear();
    }

    public bool Contains(CollectionResponse<T> item)
    {
        return ((ICollection<CollectionResponse<T>>)collectionResponses).Contains(item);
    }

    public void CopyTo(CollectionResponse<T>[] array, int arrayIndex)
    {
        ((ICollection<CollectionResponse<T>>)collectionResponses).CopyTo(array, arrayIndex);
    }

    public bool Remove(CollectionResponse<T> item)
    {
        return ((ICollection<CollectionResponse<T>>)collectionResponses).Remove(item);
    }

    IEnumerator<CollectionResponse<T>> IEnumerable<CollectionResponse<T>>.GetEnumerator()
    {
        return ((IEnumerable<CollectionResponse<T>>)collectionResponses).GetEnumerator();
    }
}

public class PagesCollectionEnumerator<T> : IEnumerator<Resource<T>>, IEnumerator
{
    public List<CollectionResponse<T>> collectionResponses;

    // Enumerators are positioned before the first element
    // until the first MoveNext() call.
    int indexPosition = -1;
    int listPosition = 0;

    public PagesCollectionEnumerator(List<CollectionResponse<T>> list)
    {
        collectionResponses = list;
    }

    public bool MoveNext()
    {
        indexPosition++;

        // if there is a next collection response to move to, move to it
        // if Data is null, try to move to the next collection response
        if (indexPosition == (collectionResponses[listPosition].Data?.Count ?? indexPosition)
            && listPosition < collectionResponses.Count - 1)
        {
            indexPosition = 0;
            listPosition++;
        }

        // if Data is null, return false
        return indexPosition < (collectionResponses[listPosition].Data?.Count ?? int.MinValue);
    }

    public void Reset()
    {
        indexPosition = 0;
        listPosition = -1;
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    Resource<T> IEnumerator<Resource<T>>.Current
    {
        get
        {
            return Current;
        }
    }

    public Resource<T> Current
    {
        get
        {
            try
            {
                return collectionResponses[listPosition].Data?[indexPosition]!;
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }

    void IDisposable.Dispose()
    {

    }

    ~PagesCollectionEnumerator()
    {

    }
}