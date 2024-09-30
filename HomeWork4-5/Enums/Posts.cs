using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    /// <summary>
    /// Должности компании
    /// </summary>
    public enum Post
    {
        /// <summary>
        /// Руководитель или менеджер проекта, ответственный за управление командой.
        /// </summary>
        Manager = 1,

        /// <summary>
        /// Разработчик программного обеспечения.
        /// </summary>
        Developer = 2,

        /// <summary>
        /// Дизайнер, ответственный за визуальное оформление и дизайн.
        /// </summary>
        Designer = 3,

        /// <summary>
        /// Тестировщик, проверяющий качество программного обеспечения.
        /// </summary>
        Tester = 4,

        /// <summary>
        /// Аналитик, анализирующий требования и бизнес-процессы.
        /// </summary>
        Analyst = 5,

        /// <summary>
        /// Архитектор, разрабатывающий архитектуру программных решений.
        /// </summary>
        Architect = 6,

        /// <summary>
        /// Инженер DevOps, ответственный за внедрение DevOps практик и поддержание инфраструктуры.
        /// </summary>
        DevOpsEngineer = 7,

        /// <summary>
        /// Владелец продукта, ответственный за управление требованиями и приоритетами продукта.
        /// </summary>
        ProductOwner = 8,

        /// <summary>
        /// Скрам-мастер, координирующий работу команды в соответствии с методологией Scrum.
        /// </summary>
        ScrumMaster = 9,

        /// <summary>
        /// Специалист по управлению персоналом (HR).
        /// </summary>
        HR = 10,

        /// <summary>
        /// Менеджер по продажам, отвечающий за продажи и развитие клиентской базы.
        /// </summary>
        SalesManager = 11,

        /// <summary>
        /// Специалист по маркетингу, разрабатывающий и реализующий маркетинговые стратегии.
        /// </summary>
        MarketingSpecialist = 12,

        /// <summary>
        /// Инженер поддержки, обеспечивающий техническую поддержку клиентов и пользователей.
        /// </summary>
        SupportEngineer = 13
    }

}
