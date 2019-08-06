/*****************************************************************************************
 * Copyright (c) 2008-2019 kelvin(kelvin@onloch.com)
 * 梁乔峰版权所有2008-2019。
 * 本软件文档资料是梁乔峰的资产,任何人士阅读和使用本资料必
 * 须获得相应的书面授权,承担保密责任和接受相应的法律束.
 ****************************************************************************************
 * FileName:IBaseRepository.cs
 * Author:梁乔峰(5768534@qq.com)
 * CreateDate:2019/05/07 21:43:58
 * Description:
 *     公共基础仓储接口
 * <version>|<author>            |<time>                                    |<desc>
 * 1        |梁乔峰              |2019/05/07 21:43:58                       |创建公共基础仓储接口
*****************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Maydear.Repositories
{
    /// <summary>
    /// 基础仓储层
    /// </summary>
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// 链接同步实体
        /// </summary>
        /// <param name="entity">待同步的实体，主要根据主键为链接同步依据</param>
        void Attach(T entity);

        /// <summary>
        /// 链接同步实体集合
        /// </summary>
        /// <param name="entities">待同步的实体集合，主要根据主键为链接同步依据</param>
        void AttachRange(params T[] entities);

        /// <summary>
        /// 增加实体
        /// </summary>
        /// <param name="entity">待添加的实体</param>
        /// <returns>成功则返回True，失败则返回false</returns>
        bool Add(T entity);

        /// <summary>
        /// 增加实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <returns>成功则返回True，失败则返回false</returns>
        bool AddRange(IList<T> entities);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">实体加工参数</param>
        /// <returns>成功则返回True，失败则返回false</returns>
        bool Change(T entity);

        /// <summary>
        /// 更新实体集合
        /// </summary>
        /// <param name="entities">实体更新的实体集合</param>
        /// <returns>成功则返回True，失败则返回false</returns>
        bool ChangeRange(IList<T> entities);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="condition">待更新实体的搜索条件</param>
        /// <param name="actionEntity">搜索后所做的操作</param>
        /// <returns>成功则返回True，失败则返回false</returns>
        bool Change(Expression<Func<T, bool>> condition, Action<T> actionEntity);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="condition">待更新实体的搜索条件</param>
        /// <param name="actionEntities">待更新实体</param>
        /// <returns>成功则返回True，失败则返回false</returns>
        bool ChangeRange(Expression<Func<T, bool>> condition, Action<IList<T>> actionEntities);

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity">移除的实体</param>
        /// <returns>成功则返回True，失败则返回false</returns>
        bool Remove(T entity);

        /// <summary>
        /// 按指定条件移除实体
        /// </summary>
        /// <param name="condition">待删除实体的条件</param>
        /// <returns>成功则返回True，失败则返回false</returns>
        bool Remove(Expression<Func<T, bool>> condition);

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns>返回单个实体，如果存在多个实体时返回第一个</returns>
        T GetEntity(Expression<Func<T, bool>> condition);

        /// <summary>
        /// 获取实体并分页，
        /// </summary>
        /// <param name="condition">条件</param>
        /// <param name="page">分页规则</param>
        /// <returns>返回带分页信息的实体集</returns>
        IPageCollection<T> GetPageEntities(Page page, Expression<Func<T, bool>> condition);


        /// <summary>
        /// 根据升序规则获取实体并分页
        /// </summary>
        /// <param name="condition">条件</param>
        /// <param name="page">分页规则</param>
        /// <param name="orderBySelector">升序排序键</param>
        /// <returns>返回带分页信息的实体集</returns>
        IPageCollection<T> GetPageEntities<TKey>(Page page, Expression<Func<T, bool>> condition, Expression<Func<T, TKey>> orderBySelector);

        /// <summary>
        /// 根据降序规则获取实体并分页
        /// </summary>
        /// <param name="condition">条件</param>
        /// <param name="page">分页规则</param>
        /// <param name="orderBySelector">降序排序键</param>
        /// <returns>返回带分页信息的实体集</returns>
        IPageCollection<T> GetPageEntitiesOrderByDescending<TKey>(Page page, Expression<Func<T, bool>> condition, Expression<Func<T, TKey>> orderBySelector);

        /// <summary>
        /// 获取指定条件的实体集合
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns>返回实体集</returns>
        IEnumerable<T> GetEntities(Expression<Func<T, bool>> condition);

        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <param name="queryAction">获取实体集合的委托</param>
        /// <returns>返回实体集</returns>
        IEnumerable<T> GetEntities(Func<IQueryable<T>, IEnumerable<T>> queryAction);

        /// <summary>
        /// 根据升序规则获取指定条件的实体集合
        /// </summary>
        /// <param name="condition">条件</param>
        /// <param name="orderBySelector">升序排序键</param>
        /// <returns>返回实体集</returns>
        IEnumerable<T> GetEntities<TKey>(Expression<Func<T, bool>> condition, Expression<Func<T, TKey>> orderBySelector);

        /// <summary>
        /// 根据降序规则获取指定条件的实体集合
        /// </summary>
        /// <param name="condition">条件</param>
        /// <param name="orderBySelector">降序排序键</param>
        /// <returns>返回实体集</returns>
        IEnumerable<T> GetEntitiesOrderByDescending<TKey>(Expression<Func<T, bool>> condition, Expression<Func<T, TKey>> orderBySelector);

        /// <summary>
        /// 按照指定条件获取数量
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns>返回满足当前条件的实体数量</returns>
        long Count(Expression<Func<T, bool>> condition);

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="condition">判断条件</param>
        /// <returns>如果存在则返回true，反之则为false</returns>
        bool Exists(Expression<Func<T, bool>> condition);
    }
}   
