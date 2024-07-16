import styles from './page.module.css'

async function getWeather() {
    const cmsApi = process.env['services__api__http__0']
    const res = await fetch(`${cmsApi}/weatherforecast`)
    if (!res.ok) {
        throw new Error('Failed to fetch weather data')
    }
    return res.json()
}

async function getBlogs() {
    const cmsApi = process.env['services__api__http__0']
    const res = await fetch(`${cmsApi}/blogs`)
    if (!res.ok) {
        throw new Error('Failed to fetch blog data')
    }
    return res.json()
}
export default async function Home() {
    const data = await getWeather();
    const blogData = await getBlogs();
    return (
        
        <div className={styles.contentWrapper}>
            {/* TODO: Figure out component/page structure */}
            <p>Home</p>
            <table className={styles.weatherTable}>
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Temp C</th>
                        <th>Temp F</th>
                        <th>Summary</th>
                    </tr>
                </thead>
                <tbody>
                    {data.map((data: { date: string, temperatureC: number, temperatureF: number, summary: string }) => (
                        <tr key={data.date}>
                            <td>{data.date}</td>
                            <td>{data.temperatureC}</td>
                            <td>{data.temperatureF}</td>
                            <td>{data.summary}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
            <table className={styles.blogTable}>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Title</th>
                        <th>CreatedDate</th>
                        <th>UpdatedDate</th>
                    </tr>
                </thead>
                <tbody>
                {blogData.map((blogData: { id: string, name: string, createdAt: string, updatedAt: string}) => (
                    <tr>
                        <td>{blogData.id}</td>
                        <td>{blogData.name}</td>
                        <td>{blogData.createdAt}</td>
                        <td>{blogData.updatedAt}</td>
                    </tr>
                ))}
                </tbody>
            </table>
        </div>
    )
}