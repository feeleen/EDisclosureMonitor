using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EDisclosureMonitor
{
	public class SemaphoreLocker : IDisposable
	{
		private readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

		public async Task LockAsync(Func<Task> worker)
		{
			await semaphore.WaitAsync();

			try
			{
				await worker();
			}
			finally
			{
				semaphore.Release();
			}
		}

		public async Task<T> LockAsync<T>(Func<Task<T>> worker)
		{
			await semaphore.WaitAsync();
			try
			{
				return await worker();
			}
			finally
			{
				semaphore.Release();
			}
		}

		public void Dispose()
		{
			try
			{
				semaphore?.Release();
			}
			catch { }
		}
	}
}
